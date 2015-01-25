using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml;
using TranslatorInterface;
/*
Android String Resource Translation Tool
Copyright (C) 2010 Futon Redemption

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
namespace AndroidProjectManipulator
{
    public class ResourceTranslator
    {
        public AndroidProject Project { get; private set; }
        public Language SourceLanguage { get; set; }
        public ITranslator Translator { get; set; }

        public ResourceTranslator(AndroidProject project, ITranslator translator, Language sourceLanguage)
        {
            this.Project = project;
            this.Translator = translator;
            this.SourceLanguage = sourceLanguage;
        }

        public void TranslateProject()
        {
            List<string> xmlfiles = Util.LoadFiles(this.Project.ValuesDirectory, "*.xml");

            List<Language> languages = Translator.GetSupportedLanguages();
            List<ThreadedTranslator> ltt = new List<ThreadedTranslator>();

            foreach (Language lang in languages)
            {
                if (lang.BaseLanguage != SourceLanguage.BaseLanguage)
                {
                    ThreadedTranslator tt = new ThreadedTranslator((ITranslator)Translator.Clone(), SourceLanguage, lang, xmlfiles);
                    tt.BeginTranslation();
                    ltt.Add(tt);
                }
            }

            foreach (ThreadedTranslator tt in ltt)
            {
                tt.WaitForEnd();
            }
        }

        private class ThreadedTranslator
        {
            public ITranslator Translator { get; private set; }
            public Language SourceLanguage { get; private set; }
            public Language DestLanguage { get; private set; }
            public List<string> Files { get; private set; }
            private Thread asyncTask;

            public ThreadedTranslator(ITranslator translator, Language srclang, Language destlang, List<string> files)
            {
                Translator = translator;
                SourceLanguage = srclang;
                DestLanguage = destlang;
                Files = files;
            }

            public void AsyncTranslate()
            {
                foreach (string xmlfile in Files)
                {
                    TranslateFile(xmlfile);
                }
            }
            public void BeginTranslation()
            {
                asyncTask = new Thread(new ThreadStart(this.AsyncTranslate));
                asyncTask.Start();
            }

            public void WaitForEnd()
            {
                asyncTask.Join(10000);
            }

            private class XmlNodeTranslationQueue
            {
                public List<XmlNode> DeletingNodes = new List<XmlNode>();
                public List<XmlNode> TranslatingNodes = new List<XmlNode>();
                private Language SourceLanguage;
                private Language DestLanguage;
                private ITranslator Translator;
                private XmlDocument XmlDoc;

                public XmlNodeTranslationQueue(XmlDocument doc, ITranslator translator, Language sourceLanguage, Language destLanguage)
                {
                    XmlDoc = doc; 
                    Translator = translator;
                    SourceLanguage = sourceLanguage;
                    DestLanguage = destLanguage;
                }

                public void AddNode(XmlNode node)
                {
                    bool dont_convert = false;
                    // if the string name starts with nolocal_ then ignore it.
                    if (node.Attributes.GetNamedItem("name").Value.StartsWith("nolocal_"))
                    {
                        dont_convert = true;
                    }
                    // Don't convert resource references.
                    if (node.InnerXml.StartsWith("@"))
                    {
                        dont_convert = true;
                    }

                    if (!dont_convert)
                    {
                        TranslatingNodes.Add(node);
                    }
                    else
                    {
                        DeletingNodes.Add(node);
                    }
                }

                public bool TranslateContent()
                {
                    if (this.TranslatingNodes.Count > 0)
                    {
                        List<string> translated_text = Translator.Translate(GetContent(), SourceLanguage, DestLanguage);
                        MergeTranslation(translated_text);
                        DeleteUntranslatedNodes();
                    }

                    return this.TranslatingNodes.Count > 0;
                }

                private void DeleteUntranslatedNodes()
                {
                    // Delete all entries that don't need to be in there.
                    foreach (XmlNode del_target in this.DeletingNodes)
                    {
                        del_target.ParentNode.RemoveChild(del_target);
                    }
                }

                public List<string> GetContent()
                {
                    List<string> result = new List<string>();
                    foreach (XmlNode node in TranslatingNodes)
                    {
                        result.Add(node.InnerXml);
                    }
                    return result;
                }

                private void MergeTranslation(List<string> translated)
                {
                    int i;
                 
                    for(i = 0; i < TranslatingNodes.Count; i++)
                    {
                        string translated_string = translated[i];
                        XmlNode cnode = TranslatingNodes[i];

                        if (translated_string != null)
                        {
                            translated_string = translated_string.Trim();
                        }

                        if (translated_string == null || translated_string.StartsWith(cnode.InnerXml.Trim()))
                        {
                            DeletingNodes.Add(cnode);
                        }
                        else
                        {
                            cnode.InnerXml = FixTranslationFormatting(translated_string);
                        }
                    }
                }

                private string FixTranslationFormatting(string translated_string)
                {
                    string corrected = translated_string.Replace(@"\ '", @"\'");
                    string[] splits = corrected.Split(new string[] { @"'" }, System.StringSplitOptions.RemoveEmptyEntries);

                    if (splits.Length == 1)
                    {
                        corrected = splits[0];
                    }
                    else if (splits.Length > 1)
                    {
                        corrected = "";

                        for (int i = 0; i < splits.Length; i++)
                        {
                            string data = splits[i];
                            if (data.EndsWith(@"\"))
                            {
                                corrected += data + @"'";
                            }
                            else
                            {
                                corrected += data + @"\'";
                            }
                        }
                    }
                    return corrected.Trim();
                }
            }

            private void TranslateFile(string xmlfile)
            {
                XmlDocument doc = new XmlDocument();

                doc.Load(xmlfile);
                XmlNodeList targets = doc.GetElementsByTagName("string");

                XmlNodeTranslationQueue queue = new XmlNodeTranslationQueue(doc, Translator, SourceLanguage, DestLanguage);
                
                foreach (XmlNode node in targets)
                {
                    queue.AddNode(node);
                }

                bool has_changes = queue.TranslateContent();
                if (has_changes)
                {
                    string dir = Path.GetDirectoryName(xmlfile);
                    string filename = Path.GetFileName(xmlfile);
                    string parentdir = Path.GetDirectoryName(dir);
                    string dirname = Path.GetFileName(dir);

                    string language_extension_dir = DestLanguage.ToString();

                    // HACK
                    if (language_extension_dir.Equals("zh-CHS") || language_extension_dir.Equals("zh-rCHS"))
                    {
                        language_extension_dir = "zh";
                    }
                    if (language_extension_dir.Equals("zh-CHT") || language_extension_dir.Equals("zh-rCHT"))
                    {
                        language_extension_dir = "zh-rTW";
                    }

                    dir = Path.Combine(parentdir, dirname + "-" + language_extension_dir);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    xmlfile = Path.Combine(dir, filename);
                    doc.Save(xmlfile);
                }
            }
        }
    }
}

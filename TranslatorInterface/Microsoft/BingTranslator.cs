using System;
using System.Collections.Generic;
using TranslatorInterface.net.bing.api;

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
namespace TranslatorInterface.Microsoft
{
    [TranslatorDeclaration("Bing Translator - http://www.bing.com/", "http://www.bing.com/developers/createapp.aspx")]
    public class BingTranslator : ITranslator
    {
        private readonly string _apikey;

        public static BingTranslator CreateBingTranslator(string apikey)
        {
            return new BingTranslator(apikey);
        }

        public BingTranslator(string apikey)
        {
            _apikey = apikey;
        }

        private static string LangToString(Language lang)
        {
            string result = "";

            result = lang.BaseLanguage;

            return result;
        }
        public string Translate(string src, Language src_lang, Language dest_lang)
        {
            String result = null;

            BingService bs = new BingService();
            SearchRequest sr = new SearchRequest();
            sr.AppId = _apikey;
            sr.Sources = new SourceType[] { SourceType.Translation };

            sr.Translation = new TranslationRequest();
            sr.Translation.SourceLanguage = LangToString(src_lang);
            sr.Translation.TargetLanguage = LangToString(dest_lang);
            sr.Query = src;
            sr.Version = "2.2";

            src = Unformat(src);

            SearchResponse response = bs.Search(sr);
            if (response != null)
            {
                if (response.Translation != null)
                {
                    if (response.Translation.Results != null)
                    {
                        if (response.Translation.Results.Length > 0)
                        {
                            result = response.Translation.Results[0].TranslatedTerm;

                            if (result.CompareTo(src) == 0)
                            {
                                result = null;
                            }
                            else if (result.Length == 0)
                            {
                                result = null;
                            }
                        }
                    }
                }
            }

            if (result != null)
            {
                result = Format(result);
            }

            return result;
        }

        private static string Unformat(string txt)
        {
            return txt.Replace(@"\'", @"'");
        }

        private static string Format(string txt)
        {
            return txt.Replace(@"'", @"\'");
        }

        public List<Language> GetSupportedLanguages()
        {
            List<Language> result = new List<Language>();

            result.Add(new Language("En"));
            result.Add(new Language("Ar"));
            result.Add(new Language("zh", "CHS"));
            result.Add(new Language("zh", "CHT"));
            result.Add(new Language("Nl"));
            result.Add(new Language("Fr"));
            result.Add(new Language("De"));
            result.Add(new Language("It"));
            result.Add(new Language("Ja"));
            result.Add(new Language("Ko"));
            result.Add(new Language("Pl"));
            result.Add(new Language("Pt"));
            result.Add(new Language("Ru"));
            result.Add(new Language("Es"));

            return result;
        }


        public List<string> Translate(List<string> content, Language src_lang, Language dest_lang)
        {
            List<string> result = new List<string>();

            foreach (string text in content)
            {
                result.Add(Translate(text, src_lang, dest_lang));
            }

            return result;
        }

        public object Clone()
        {
            return new BingTranslator(this._apikey);
        }
    }
}
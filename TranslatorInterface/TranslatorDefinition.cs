using System;
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
namespace TranslatorInterface
{
    public class TranslatorDefinition
    {
        public Type TranslatorType { get; private set; }
        public String Name { get; private set; }
        public String GetApiKeyUrl { get; private set; }

        public TranslatorDefinition(Type t)
        {
            TranslatorType = t;
            Name = TranslatorType.Name;
            GetApiKeyUrl = null;

            object[] attrs = TranslatorType.GetCustomAttributes(false);
            foreach (object attr in attrs)
            {
                if (attr is TranslatorDeclarationAttribute)
                {
                    TranslatorDeclarationAttribute tdattr = (TranslatorDeclarationAttribute)attr;
                    this.Name = tdattr.Name;
                    this.GetApiKeyUrl = tdattr.GetApiKeyWebsite;
                }
            }
        }

        public ITranslator CreateInstance(string apikey)
        {
            return (ITranslator)Activator.CreateInstance(TranslatorType, apikey);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

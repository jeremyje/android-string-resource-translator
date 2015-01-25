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
    /// <summary>
    /// http://developer.android.com/guide/topics/resources/resources-i18n.html
    /// </summary>
    public class Language
    {
        public string BaseLanguage { get; set; }
        public string Region { get; set; }

        public Language()
        {
        }

        public Language(string baselang)
        {
            BaseLanguage = baselang;
        }

        public Language(string baselang, string region)
        {
            BaseLanguage = baselang;
            Region = region;
        }

        public override string ToString()
        {
            string result = BaseLanguage;

            if (Region != null)
            {
                result += "-r" + Region;
            }

            return result;
        }

        public static Language GetDefaultLanguage()
        {
            return new Language("en", "US");
        }

        /*
        public static List<Language> GetSupportedLanguages()
        {
            List<Language> result = new List<Language>();

            //result.Add(new Language("En"));
            result.Add(new Language("Ar"));
            //result.Add(new Language("zh", "CHS"));
            //result.Add(new Language("zh", "CHT"));
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
         */
    }
}

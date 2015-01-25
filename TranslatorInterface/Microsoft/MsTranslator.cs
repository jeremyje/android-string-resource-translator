using System.Collections.Generic;
using TranslatorInterface.MicrosoftTranslator;
using System.ServiceModel;
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
    [TranslatorDeclaration("Microsoft Translator - http://www.microsofttranslator.com/", "http://www.bing.com/developers/createapp.aspx")]
    public class MsTranslator : ITranslator
    {
        MicrosoftTranslator.LanguageServiceClient _client;
        string _apiKey;
        string _sessionToken;
        private const int ONE_HOUR = 60 * 60;

        public MsTranslator(string apikey)
        {
            _apiKey = apikey;
            CreateClient();
            GetSessionToken();
        }

        private const int TEN_MEGS = 1024 * 1024 * 10;
        private void CreateClient()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = TEN_MEGS;
            EndpointAddress endpoint = new EndpointAddress("http://api.microsofttranslator.com/V2/soap.svc");
            _client = new LanguageServiceClient(binding, endpoint);
        }

        private void GetSessionToken()
        {
            _sessionToken = _client.GetAppIdToken(GetApiKey(), 5, 5, ONE_HOUR);
        }

        public List<Language> GetSupportedLanguages()
        {
            string [] languages = _client.GetLanguagesForTranslate(_sessionToken);
            List<Language> result = new List<Language>();

            foreach (string lang in languages)
            {
                result.Add(new Language(lang));
            }

            return result;
        }

        private string GetApiKey()
        {
            return _apiKey;
        }

        private string GetAppId()
        {
            return _sessionToken;
        }

        public string Translate(string content, Language src_lang, Language dest_lang)
        {
            string result = _client.Translate(GetAppId(), content, src_lang.BaseLanguage, dest_lang.BaseLanguage);
            return result;
        }

        public List<string> Translate(List<string> content, Language src_lang, Language dest_lang)
        {
            List<string> result = new List<string>();
            TranslateOptions options = new TranslateOptions();
            TranslateArrayResponse[] results = _client.TranslateArray(GetAppId(), content.ToArray(), src_lang.BaseLanguage, dest_lang.BaseLanguage, options);

            foreach(TranslateArrayResponse response in results)
            {
                result.Add(response.TranslatedText);
            }

            return result;
        }

        public object Clone()
        {
            return new MsTranslator(this.GetApiKey());
        }
    }
}

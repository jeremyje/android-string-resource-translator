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
using System.Collections.Generic;
using System;
namespace TranslatorInterface
{
    public class TranslationService
    {
        private ITranslator _translator;

        public TranslationService(ITranslator translator)
        {
            this._translator = translator;
        }


        public static List<TranslatorDefinition> GetAvailableTranslators()
        {
            List<TranslatorDefinition> result = new List<TranslatorDefinition>();
            List<Type> types = GetAvailableTranslatorTypes();
            foreach (Type type in types)
            {
                result.Add(new TranslatorDefinition(type));
            }

            return result;
        }

        static List<Type> GetAvailableTranslatorTypes()
        {
            List<Type> result;
            result = TypeResolver<ITranslator>.GetTypes();
            return result;
        }
    }
}

﻿using System;
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
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited=false)]
    public class TranslatorDeclarationAttribute : Attribute
    {
        public string Name { get; private set; }
        public string GetApiKeyWebsite { get; private set; }
        public TranslatorDeclarationAttribute(string name, string getApiKeyWebsite)
        {
            Name = name;
            GetApiKeyWebsite = getApiKeyWebsite;
        }
    }
}

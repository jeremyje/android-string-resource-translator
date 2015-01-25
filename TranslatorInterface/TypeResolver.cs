using System;
using System.Collections.Generic;
using System.Reflection;
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
    class TypeResolver<T>
    {
        public static List<Type> GetTypes()
        {
            List<Type> result = new List<Type>();
            Type[] genericsOfList = new List<T>().GetType().GetGenericArguments();
            Type targetType = genericsOfList[0];

            AppDomain domain = AppDomain.CurrentDomain;
            Assembly[] assemblies = domain.GetAssemblies();
            
            foreach(Assembly asm in assemblies)
            {
                Type[] types = asm.GetTypes();
                foreach(Type type in types)
                {
                    foreach (Type iface in type.GetInterfaces())
                    {
                        if (iface.Equals(targetType))
                        {
                            result.Add(type);
                        }
                    }
                }
            }

            return result;
        }
    }
}

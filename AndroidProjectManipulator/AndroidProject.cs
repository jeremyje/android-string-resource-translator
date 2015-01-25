using System.Collections.Generic;
using System.IO;
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
    public class AndroidProject
    {
        public static bool IsProject(string path)
        {
            string ppath = Path.Combine(path, "AndroidManifest.xml");

            return File.Exists(ppath);
        }

        public string ProjectDirectory { get; private set; }

        public string AssetDirectory { get { return Path.Combine(ProjectDirectory, "asset"); } }
        public string BinaryDirectory { get { return Path.Combine(ProjectDirectory, "bin"); } }
        public string GeneratedDirectory { get { return Path.Combine(ProjectDirectory, "gen"); } }
        public string SourceDirectory { get { return Path.Combine(ProjectDirectory, "src"); } }
        public string ResourceDirectory { get { return Path.Combine(ProjectDirectory, "res"); } }

        public string AnimationDirectory { get { return Path.Combine(ResourceDirectory, "anim"); } }
        public string LayoutDirectory { get { return Path.Combine(ResourceDirectory, "layout"); } }
        public string ValuesDirectory { get { return Path.Combine(ResourceDirectory, "values"); } }
        public string RawDirectory { get { return Path.Combine(ResourceDirectory, "raw"); } }

        public string ManifestFile { get { return Path.Combine(ProjectDirectory, "AndroidManifest.xml"); } }

        public AndroidProject(string path)
        {
            this.ProjectDirectory = path;
        }

        public List<string> GetXmlFiles()
        {
            return Util.LoadFiles(ProjectDirectory, "*.xml");
        }
    }
}

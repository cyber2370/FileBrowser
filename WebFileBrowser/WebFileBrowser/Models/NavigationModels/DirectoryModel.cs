using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebFileBrowser.Models.NavigationModels
{
    public class DirectoryModel
    {
        public DirectoryModel()
        {

        }

        public DirectoryModel(string path)
        {
            FullPath = path;
        }

        public string Name { get; private set; }

        private string _fullPath;
        public string FullPath
        {
            get
            {
                return _fullPath;
            }
            set
            {
                _fullPath = value;
                
                Name = Path.GetDirectoryName(_fullPath);
            }
        }

        public IList<string> Files { get; set; }

        public IList<string> Directories { get; set; }

    }
}
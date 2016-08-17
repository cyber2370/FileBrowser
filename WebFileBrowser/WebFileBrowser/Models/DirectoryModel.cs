using System.Collections.Generic;
using System.Linq;

namespace WebFileBrowser.Models
{
    public class DirectoryModel
    {
        public string Name { get; private set; }

        public string DriveLetter { get;set; }

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

                Name = _fullPath.Split('\\', '/').Last();
            }
        }

        public IList<string> Directories { get; set; }

        public IList<FileModel> Files { get; set; }


    }
}
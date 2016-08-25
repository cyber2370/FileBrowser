using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebFileBrowser.Models.NavigationModels
{
    public class DirectoryModel
    {
        public string Name { get; private set; }

        public string DriveLetter { get; private set; }

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
                DriveLetter = _fullPath.Split('\\').First();
            }
        }

        public IList<DirectoryModel> Directories { get; set; }

        public IList<FileModel> InsertedFiles { get; set; }

        public IList<FileModel> Files { get; set; }

    }
}
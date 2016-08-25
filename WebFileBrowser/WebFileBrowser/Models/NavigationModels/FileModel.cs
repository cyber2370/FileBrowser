using System.IO;
using System.Web;

namespace WebFileBrowser.Models.NavigationModels
{
    public class FileModel
    {
        public string Name { get; private set; }

        public string Extension { get; private set; }

        public string MimeType { get; private set; }

        public long FileSize { get; private set; }

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

                MimeType = MimeMapping.GetMimeMapping(_fullPath);
                Extension = Path.GetExtension(_fullPath);
                Name = Path.GetFileNameWithoutExtension(_fullPath);
                FileSize = new FileInfo(_fullPath).Length;
            }
        }

    }
}
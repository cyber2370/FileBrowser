using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFileBrowser.Models
{
    public class FileModel
    {
        public string Name { get; set; }

        public string Exstension { get; set; }

        public string Path { get; set; }

        public string MimeType { get; set; }

        public long FileSize { get; set; }
    }
}
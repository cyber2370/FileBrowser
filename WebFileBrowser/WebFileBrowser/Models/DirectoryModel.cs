using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFileBrowser.Models
{
    public class DirectoryModel
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public IList<FileModel> Files { get; set; }

        public IList<DirectoryModel> Directories { get; set; }

    }
}
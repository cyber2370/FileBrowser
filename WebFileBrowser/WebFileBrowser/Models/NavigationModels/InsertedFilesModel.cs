using System.Collections.Generic;

namespace WebFileBrowser.Models.NavigationModels
{
    public class InsertedFilesModel
    {
        public string RootFolderPath { get; set; }

        public IList<FileModel> Files { get; set; }
    }
}
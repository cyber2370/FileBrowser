using System.Collections.Generic;
using WebFileBrowser.Models.NavigationModels;

namespace WebFileBrowser.Data.Repositories
{
    public interface IFileRepository
    {
        IList<string> GetLogicalDrives();

        DirectoryModel GetDir(string path);

        IList<long> GetInsertedFilesSizes(string path);
    }
}
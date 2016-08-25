using System.Collections.Generic;
using WebFileBrowser.Models.NavigationModels;

namespace WebFileBrowser.Data.Repositories
{
    public interface IFileRepository
    {
        List<string> GetLogicalDrives();
        DirectoryModel GetDir(string path);
    }
}
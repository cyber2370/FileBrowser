using System.Collections.Generic;
using System.Threading.Tasks;
using WebFileBrowser.Models;

namespace WebFileBrowser.Data.Repositories
{
    public interface IFileRepository
    {
        List<string> GetLogicalDrives();
        DirectoryModel GetDir(string path);
    }
}
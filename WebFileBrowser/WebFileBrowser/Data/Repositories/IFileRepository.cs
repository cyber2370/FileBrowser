using System.Threading.Tasks;
using WebFileBrowser.Models;

namespace WebFileBrowser.Data.Repositories
{
    public interface IFileRepository
    {
        Task<DirectoryModel> GetDir(string path);
    }
}
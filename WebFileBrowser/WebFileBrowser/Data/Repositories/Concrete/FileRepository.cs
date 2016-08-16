using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebFileBrowser.Models;

namespace WebFileBrowser.Data.Repositories.Concrete
{
    class FileRepository : IFileRepository
    {
        public DirectoryModel GetDir(string path)
        {
            var directory = new DirectoryModel();

            try
            {
                var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();
                directory.Files = files.Select(file => new FileModel
                {
                    Name = file.Split('/').Last(),
                    Exstension = file.Split('.').Last(),
                    Path = file,
                    FileSize = new FileInfo(file).Length,
                    MimeType = MimeMapping.GetMimeMapping(file)
                }).ToList();

            }
            catch (Exception ex)
            {
                throw;
            }

            return directory;
        }

        public List<string> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives().ToList();
        }
    }
}
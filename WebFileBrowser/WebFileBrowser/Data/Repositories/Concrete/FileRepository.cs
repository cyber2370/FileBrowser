using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebFileBrowser.Models;

namespace WebFileBrowser.Data.Repositories.Concrete
{
    class FileRepository : IFileRepository
    {
        public DirectoryModel GetDir(string drive, string path)
        {
            var directory = new DirectoryModel
            {
                DriveLetter = drive,
                FullPath = path
            };

            try
            {
                var files = Directory.GetFiles(drive + path, "*.*", SearchOption.TopDirectoryOnly).ToList();
                directory.Files = files.Select(file => new FileModel
                {
                    Name = file.Split('/', '\\').Last(),
                    Exstension = file.Split('.').Last(),
                    Path = Path.GetPathRoot(file),
                    FileSize = new FileInfo(file).Length,
                    MimeType = MimeMapping.GetMimeMapping(file)
                }).ToList();

                directory.Directories = Directory.GetDirectories(drive + path, "*.*", SearchOption.TopDirectoryOnly).ToList();

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
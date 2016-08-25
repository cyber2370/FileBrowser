using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebFileBrowser.Models.NavigationModels;

namespace WebFileBrowser.Data.Repositories.Concrete
{
    class FileRepository : IFileRepository
    {
        public DirectoryModel GetDir(string path)
        {
            var directory = new DirectoryModel
            {
                FullPath = path
            };

            try
            {
                var files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).ToList();
                directory.Files = files.Select(file => new FileModel
                {
                    FullPath = file
                }).ToList();

                var allFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();
                directory.InsertedFiles = files.Select(file => new FileModel
                {
                    FullPath = file
                }).ToList();

                directory.Directories = Directory.GetDirectories(path, "*.*", SearchOption.TopDirectoryOnly).Select(x => new DirectoryModel { FullPath = x}).ToList();
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

        private static IEnumerable<FileInfo> EnumerateAllFiles(DirectoryInfo directoryInfo)
        {
            FileInfo[] listOfFiles;
            try
            {
                listOfFiles = directoryInfo.GetFiles();
            }
            catch (UnauthorizedAccessException)
            {
                yield break;
            }
            var listOfDirectories = directoryInfo.GetDirectories();
            foreach (var file in listOfFiles)
                yield return file;
            foreach (var dir in listOfDirectories)
                foreach (var inf in EnumerateAllFiles(dir))
                    yield return inf;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebFileBrowser.Models.NavigationModels;

namespace WebFileBrowser.Data.Repositories.Concrete
{
    class FileRepository : IFileRepository
    {

        public IList<string> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives().ToList();
        }

        public DirectoryModel GetDir(string path)
        {
            var directory = new DirectoryModel(path);

            directory.Files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Select(d => d.Replace(path, "")).ToList();

            directory.Directories = Directory.GetDirectories(path, "*.*", SearchOption.TopDirectoryOnly).Select(f => f.Replace(path, "")).ToList();

            return directory;
        }

        public IList<long> GetInsertedFilesSizes(string path)
        {
            try
            {
                return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Select(f => Convert.ToInt64(f.Length)).ToList();
            } catch (Exception)
            {
                var files = EnumerateAllFiles(new DirectoryInfo(path)).ToList();
                return files.Select(f => f.Length).ToList(); 
            }
        }

        private IEnumerable<FileInfo> EnumerateAllFiles(DirectoryInfo directoryInfo)
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
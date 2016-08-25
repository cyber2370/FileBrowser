using System;
using System.Web.Http;
using WebFileBrowser.Data.Repositories;
using WebFileBrowser.Data.Repositories.Concrete;
using WebFileBrowser.Models.NavigationModels;

namespace WebFileBrowser.Controllers
{
    public class NavigationController : ApiController
    {
        private readonly IFileRepository _fileRepository;

        public NavigationController()
        {
            _fileRepository = new FileRepository();
        }

        /// <summary>
        /// Get logical drives
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetLogicalDrives()
        {
            var drives = _fileRepository.GetLogicalDrives();

            return Ok(drives);            
        }
        
        
        /// Get dir
        [HttpPost]
        public IHttpActionResult GetDir([FromBody]DirectoryModel model)
        {
            try
            {
                var dir = _fileRepository.GetDir(model.FullPath);

                return Ok(dir);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Permissions;
using System.Web;
using System.Web.Http;
using WebFileBrowser.Data.Repositories;
using WebFileBrowser.Data.Repositories.Concrete;
using WebFileBrowser.Models;

namespace WebFileBrowser.Controllers
{
    public class NavigationController : ApiController
    {
        private readonly IFileRepository _fileRepository;

        public NavigationController()
        {
            _fileRepository = new FileRepository();
        }

        public IHttpActionResult Get()
        {
            try
            {
                var drives = _fileRepository.GetLogicalDrives();
                return Ok(drives);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }
        
        public IHttpActionResult Get(string id)
        {
            try
            {
                var dir = _fileRepository.GetDir(id);
                return Ok(dir);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}

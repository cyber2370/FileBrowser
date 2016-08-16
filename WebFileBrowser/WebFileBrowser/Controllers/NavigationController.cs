using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Permissions;
using System.Web;
using System.Web.Http;
using WebFileBrowser.Models;

namespace WebFileBrowser.Controllers
{
    public class NavigationController : ApiController
    {
        public IHttpActionResult GetDrives()
        {
            try
            {
                return Ok(Directory.GetLogicalDrives());
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }
        
        public IHttpActionResult GetDir()
        {
            return Ok();
        }
    }
}

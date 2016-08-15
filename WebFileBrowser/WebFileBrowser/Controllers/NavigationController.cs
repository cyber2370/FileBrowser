using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebFileBrowser.Models;

namespace WebFileBrowser.Controllers
{
    public class NavigationController : ApiController
    {
        public IHttpActionResult GetProduct(int id)
        {
            var directory = new DirectoryModel
            {
                
            };

            if (directory == null)
            {
                return NotFound();
            }

            return Ok(directory);
        }
    }
}

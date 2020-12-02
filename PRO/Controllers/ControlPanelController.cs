using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO.Controllers
{
    
    public class ControlPanelController : Controller
    {
        // GET: panel/Admin
        [Authorize(Roles = "Admin")]
        [Route("panel/admin")]
        public ActionResult Admin()
        {
            return View();
        }

        // GET: panel/moderator
        [Authorize(Roles = "Moderator")]
        [Route("panel/moderator")]
        public ActionResult Moderator()
        {
            return View();
        }

        // GET: panel/Author
        [Authorize(Roles = "Author")]
        [Route("panel/author")]
        public ActionResult Author()
        {
            return View();
        }
    }
}
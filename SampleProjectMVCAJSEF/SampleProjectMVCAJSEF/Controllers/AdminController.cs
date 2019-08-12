using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProjectMVCAJSEF.Controllers
{

    public class AdminController : Controller
    {
        [Authorize(Roles = "Administrator")]
        // GET: Admin
        public ActionResult ManageUsers()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult ManageCompany()
        {
            return View();
        }
        public ActionResult ManageClients()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult ManageDropdowns()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
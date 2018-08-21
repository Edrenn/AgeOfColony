using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Caching;
using System.IO;
using System.Security.Principal;

namespace AgeOfColony.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            RoleController rc = new RoleController();
            ViewBag.UserInfos = User;

            return View();
        }
    }
}

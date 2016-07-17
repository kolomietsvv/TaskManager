using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TaskManager.BLL.Core;
using TaskManager.PL.WebAPI.Models;

namespace TaskManager.PL.WebAPI.Controllers
{
    //[AllowAnonymous] //[Authorize(Roles="admin")]
    //[AllowJsonGet]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

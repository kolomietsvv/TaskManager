using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.PL.WebAPI.Models;

namespace TaskManager.PL.WebAPI.Controllers
{
    public class SearchController : Controller
    {
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult GetAllUsersLike(UserModel request)
        {
            return Json(new { Users = UserModel.GetAllLike(request) });
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult GetAllProjectsLike(ProjectModel request)
        {
            return Json(new { Projects = ProjectModel.GetAllLike(request) });
        }
    }
}

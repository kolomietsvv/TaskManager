using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.PL.WebAPI.Models;

namespace TaskManager.PL.WebAPI.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult AddProject(ProjectModel model)
        {
            if (ModelState.IsValid)
            {
                ProjectModel.AddProject(User.Identity.Name, model.ProjectName);
                return new HttpStatusCodeResult(200, "Added project: " + model.ProjectName);
            }
            return new HttpStatusCodeResult(403, "Invalid Form");
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult GetAllProjects(string loginName)
        {
            return Json(new { Projects = ProjectModel.GetAllProjects(loginName)});
        }
    }

}

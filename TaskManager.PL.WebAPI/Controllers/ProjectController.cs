using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.PL.WebAPI.Models;

namespace TaskManager.PL.WebAPI.Controllers
{
    public class ProjectController : Controller
    {
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult GetAllTasks(Guid projectId)
        {
            return Json(new { Tasks = TaskModel.GetAllTasks(projectId) });
        }
    }
}

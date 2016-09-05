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
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult AddTask(TaskModel model)
        {
            if(ModelState.IsValid)
            {
                TaskModel.AddTask(model.ProjectId, model.Name, model.Summary, model.Deadline);
                return Json(new { TaskName = model.Name, Summary = model.Summary, Deadline=model.Deadline });
            }
            return new HttpStatusCodeResult(403, "Invalid Form");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.PL.WebAPI.Models;

namespace TaskManager.PL.WebAPI.Controllers
{
    public class TaskController : Controller
    {
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult GetAllSubTasks(Guid taskId)
        {
            return Json(new { SubTasks = SubTaskModel.GetAllSubTasks(taskId) });
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult AddSubTask(SubTaskModel model)
        {
            if (ModelState.IsValid)
            {
                SubTaskModel.AddSubTask(model.TaskId, model.Name, model.CreationTime);
                return Json(new { Name = model.Name, CreationTime = model.CreationTime });
            }
            return new HttpStatusCodeResult(403, "Invalid Form");
        }
    }
}

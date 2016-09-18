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
        public ActionResult GetAllSubtasks(Guid taskId)
        {
            return Json(new { Subtasks = SubtaskModel.GetAllSubtasks(taskId) });
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult AddSubtask(SubtaskModel model)
        {
            if (ModelState.IsValid)
            {
                SubtaskModel.AddSubtask(model.TaskId, model.Name, model.CreationTime);
                return Json(new { Name = model.Name, CreationTime = model.CreationTime });
            }
            return new HttpStatusCodeResult(403, "Invalid Form");
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult TryToDo(Guid subtaskId, string userLogin)
        {
            SubtaskModel.TryToDo(subtaskId, userLogin);
            return Json(new { SubtaskId = subtaskId, userLogin = userLogin });
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult ConfirmCompletion(Guid subtaskId)
        {
            SubtaskModel.ConfirmCompletion(subtaskId);
            return new HttpStatusCodeResult(200, "ок");
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult RejectCompletion(Guid subtaskId)
        {
            SubtaskModel.RejectCompletion(subtaskId);
            return new HttpStatusCodeResult(200, "ок");
        }
    }
}

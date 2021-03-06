﻿using System;
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
        public ActionResult GetProject(Guid projectId)
        {
            return Json(new
            {
                Contributors =ProjectModel.GetAllContributors(projectId.ToString()),
                Project = ProjectModel.GetProject(projectId.ToString()),
                Tasks = TaskModel.GetAllTasks(projectId)
            });
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult AddTask(TaskModel model)
        {
            if (ModelState.IsValid)
            {
                TaskModel.AddTask(model.ProjectId, model.Name, model.Summary, model.Deadline);
                return Json(new { Name = model.Name, Summary = model.Summary, Deadline = model.Deadline, CreationTime = new DateTime() });
            }
            return new HttpStatusCodeResult(403, "Invalid Form");
        }

        [Authorize(Roles = "User")]
        public ActionResult InviteContributor(Guid projectId, string userLogin)
        {
            if (ModelState.IsValid)
            {
                ProjectModel.AddContributor(projectId, userLogin);
                return Json(new { loginName = userLogin });
            }
            return new HttpStatusCodeResult(403, "Invalid Form");
        }

    }
}

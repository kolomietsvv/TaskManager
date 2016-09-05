using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.PL.WebAPI.Models
{
    public class TaskModel
    {
        Guid TaskId { get; set; }
        string Name { get; set; }
        string Summary { get; set; }
        DateTime Deadline { get; set; }
        DateTime CreationTime { get; set; }

        static public List<TaskModel> GetAllTasks(Guid projectId)
        {
            return ContainerLogic.projectLogic.GetAllTasks(projectId)
            .Select(ent => new TaskModel()
            {
                Name = ent.Name,
                Summary = ent.Summary,
                Deadline = ent.Deadline,
                CreationTime = ent.CreationTime
            })
            .ToList();
        }
    }
}
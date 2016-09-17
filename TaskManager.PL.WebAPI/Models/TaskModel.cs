using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.PL.WebAPI.Models
{
    public class TaskModel
    {
        public Guid ProjectId { get; set; }
        public Guid TaskId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreationTime { get; set; }

        static public List<TaskModel> GetAllTasks(Guid projectId)
        {
            return ContainerLogic.projectLogic.GetAllTasks(projectId)
            .Select(ent => new TaskModel()
            {
                Name = ent.Name,
                Summary = ent.Summary,
                Deadline = ent.Deadline,
                CreationTime = ent.CreationTime,
                TaskId=ent.TaskId
            })
            .ToList();
        }
        static public void AddTask(Guid projectId, string name, string summary, DateTime deadline)
        {
            ContainerLogic.projectLogic.AddTask(projectId, name, summary, deadline);
        }
    }
}
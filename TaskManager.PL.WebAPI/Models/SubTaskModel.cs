using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManager.PL.WebAPI.Models
{
    public class SubTaskModel
    {
        public Guid TaskId { get; set; }
        public Guid SubTaskId { get; set; }
        public string Name { get; set; }
        public DateTime CompletionTime { get; set; }
        public DateTime CreationTime { get; set; }

        static public List<SubTaskModel> GetAllSubTasks(Guid taskId)
        {
            return ContainerLogic.taskLogic.GetAllSubTasks(taskId)
            .Select(ent => new SubTaskModel()
            {
                Name = ent.Name,
                CompletionTime= ent.CompletionTime,
                CreationTime=ent.CreationTime
            })
            .ToList();
        }
        static public void AddSubTask(Guid taskId, string name, DateTime creationTime)
        {
            ContainerLogic.taskLogic.AddSubTask(taskId, name, creationTime);
        }
    }
}

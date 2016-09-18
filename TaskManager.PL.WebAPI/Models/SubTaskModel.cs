using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManager.PL.WebAPI.Models
{
    public class SubtaskModel
    {
        public Guid TaskId { get; set; }
        public Guid ProjectId { get; set; }
        public string DoneBy { get; set; }
        public Guid SubtaskId { get; set; }
        public string Name { get; set; }
        public DateTime? CompletionTime { get; set; }
        public DateTime CreationTime { get; set; }

        static public List<SubtaskModel> GetAllSubtasks(Guid taskId)
        {
            return ContainerLogic.taskLogic.GetAllSubtasks(taskId)
            .Select(ent => new SubtaskModel()
            {
                Name = ent.Name,
                CompletionTime = ent.CompletionTime,
                CreationTime = ent.CreationTime,
                SubtaskId = ent.SubtaskId,
                DoneBy=ent.DoneBy,
                ProjectId=ent.ProjectId
            })
            .ToList();
        }
        static public void AddSubtask(Guid taskId, string name, DateTime creationTime)
        {
            ContainerLogic.taskLogic.AddSubtask(taskId, name, creationTime);
        }

        static public void TryToDo(Guid subtaskId, string userLogin)
        {
            ContainerLogic.subtaskLogic.TryToDo(subtaskId, userLogin);
        }

        static public void ConfirmCompletion(Guid subtaskId)
        {
            ContainerLogic.subtaskLogic.ConfirmCompletion(subtaskId);
        }

        static public void RejectCompletion(Guid subtaskId)
        {
            ContainerLogic.subtaskLogic.RejectCompletion(subtaskId);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BLL.Interface;
using TaskManager.Common.Entities;
using TaskManager.DAL.Interface;

namespace TaskManager.BLL.Core
{
    public class TaskLogic:ITaskLogic
    {
        static ITaskDAO taskDAO = ContainerDAO.taskDAO;

        public IEnumerable<Subtask> GetAllSubtasks(Guid taskId)
        {
            return taskDAO.GetAllSubtasks(taskId);
        }

        public void AddSubtask(Guid taskId, string name, DateTime creationTime)
        {
            taskDAO.AddSubtask(taskId, name, creationTime);
        }
    }
}

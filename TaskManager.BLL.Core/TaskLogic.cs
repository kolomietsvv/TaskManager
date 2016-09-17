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

        public IEnumerable<SubTask> GetAllSubTasks(Guid taskId)
        {
            return taskDAO.GetAllSubTasks(taskId);
        }

        public void AddSubTask(Guid taskId, string name, DateTime creationTime)
        {
            taskDAO.AddSubTask(taskId, name, creationTime);
        }
    }
}

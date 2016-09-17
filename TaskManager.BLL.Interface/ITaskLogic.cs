using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Common.Entities;

namespace TaskManager.BLL.Interface
{
    public interface ITaskLogic
    {
        IEnumerable<SubTask> GetAllSubTasks(Guid taskId);
        void AddSubTask(Guid taskId, string name, DateTime creationTime);
    }
}

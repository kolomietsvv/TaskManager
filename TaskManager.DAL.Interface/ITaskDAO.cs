using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Common.Entities;

namespace TaskManager.DAL.Interface
{
    public interface ITaskDAO
    {
        IEnumerable<SubTask> GetAllSubTasks(Guid taskId);
        void AddSubTask(Guid taskId, string name, DateTime creationTime);
    }
}

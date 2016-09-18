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
        IEnumerable<Subtask> GetAllSubtasks(Guid taskId);
        void AddSubtask(Guid taskId, string name, DateTime creationTime);
    }
}

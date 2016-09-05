using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Common.Entities;

namespace TaskManager.BLL.Interface
{
    public interface IProjectLogic
    {
        List<ProjectTask> GetAllTasks(Guid projectId);
        void AddTask(Guid projectId, string name, string summary, DateTime deadline);
    }
}

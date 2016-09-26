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
        IEnumerable<User> GetAllContributors(string projectId);
        Project GetProject(string Id);
        IEnumerable<ProjectTask> GetAllTasks(Guid projectId);
        void AddTask(Guid projectId, string name, string summary, DateTime? deadline);
        IEnumerable<Project> GetAllLike(Project request);
        void AddContributor(Guid projectId, string loginName);
    }
}

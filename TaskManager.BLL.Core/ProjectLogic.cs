using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Common.Entities;
using TaskManager.DAL.Interface;
using TaskManager.BLL.Interface;

namespace TaskManager.BLL.Core
{
    public class ProjectLogic:IProjectLogic
    {
        static IProjectDAO projectDAO = ContainerDAO.projectDAO;
        public IEnumerable<ProjectTask> GetAllTasks(Guid projectId)
        {
            return projectDAO.GetAllTasks(projectId);
        }
        public void AddTask(Guid projectId, string name, string summary, DateTime deadline)
        {
            projectDAO.AddTask(projectId, name, summary, deadline);
        }
        public IEnumerable<Project> GetAllLike(Project request)
        {
            return projectDAO.GetAllLike(request);
        }
        public Project GetProject(string Id)
        {
            return projectDAO.GetProject(Id);
        }
        public IEnumerable<User> GetAllContributors(string projectId)
        {
            return projectDAO.GetAllContributors(projectId);
        }
    }
}

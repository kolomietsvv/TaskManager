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
        public List<ProjectTask> GetAllTasks(Guid projectId)
        {
            return projectDAO.GetAllTasks(projectId);
        }
        public void AddTask(Guid projectId, string name, string summary, DateTime deadline)
        {
            projectDAO.AddTask(projectId, name, summary, deadline);
        }
    }
}

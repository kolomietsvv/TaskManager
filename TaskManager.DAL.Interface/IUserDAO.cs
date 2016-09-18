using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Common.Entities;

namespace TaskManager.DAL.Interface
{
    public interface IUserDAO
    {
        
        IEnumerable<User> GetAll();
        void AddUser(User user);
        User GetUser(string login);
        bool CanLogin(string login, string password);
        void AddRole(string userId, string roleName);
        void AddProject(string login, string projectName, string summary);
        IEnumerable<Project> GetAllProjects(string loginName);
        IEnumerable<User> GetAllLike(User request);
        void DeleteRole(string userId, string roleName);
    }
}

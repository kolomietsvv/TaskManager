using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Common.Entities;

namespace TaskManager.BLL.Interface
{
    public interface IUserLogic
    {
       IEnumerable<User> GetAll();
       void AddUser(User user);
       User GetUser(string loogin);
       bool CanLogin(string login, string password);
       void AddRole(string loginName, string roleName);
    }
}

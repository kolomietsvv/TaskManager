﻿using System;
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
       User GetUser(string userLogin);
       bool CanLogin(string userLogin, string password);
       void AddRole(string userId, string roleName);
       void AddProject(string userLogin, string projectName, string summary);
       IEnumerable<Project> GetAllProjects(string userLogin);
       IEnumerable<User> GetAllLike(User request);
       void DeleteRole(string loginName, string roleName);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Common.Entities;
using TaskManager.BLL.Interface;
using TaskManager.DAL.MSSQL;
using TaskManager.DAL.Interface;

namespace TaskManager.BLL.Core
{
    public class UserLogic: IUserLogic
    {
        static IUserDAO userDAO = ContainerDAO.userDAO;
        public IEnumerable<User> GetAll()
        {
            return userDAO.GetAll();
        }
        public void AddUser(User user)
        {
            userDAO.AddUser(user);
        }
        public User GetUser(string login) 
        {
            return userDAO.GetUser(login);
        }
        public bool CanLogin(string loginName, string passwordHash)
        {
            return userDAO.CanLogin(loginName, passwordHash);
        }
        public void AddRole(string userId, string roleName)
        {
            userDAO.AddRole(userId, roleName);
        }
        public void AddProject(string userLogin, string projectName)
        {
            userDAO.AddProject(userLogin, projectName);
        }
        public List<Project> GetAllProjects(string userLogin) 
        {
           return  userDAO.GetAllProjects(userLogin);
        }
    }
}

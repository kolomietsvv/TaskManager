﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DAL.Interface;
using TaskManager.DAL.MSSQL;

namespace TaskManager.BLL.Core
{
    class ContainerDAO
    {
        public static IUserDAO userDAO;
        static ContainerDAO()
        {
            userDAO = new UserDAO();
        }
    }
}

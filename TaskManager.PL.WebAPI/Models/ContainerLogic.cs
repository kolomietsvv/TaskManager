using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.BLL.Interface;
using TaskManager.BLL.Core;

namespace TaskManager.PL.WebAPI.Models
{
    public class ContainerLogic
    {
        public static IUserLogic userLogic;
        static ContainerLogic()
        {
            userLogic = new UserLogic();
        }
    }
}
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
        public static IProjectLogic projectLogic;
        public static ITaskLogic taskLogic;
        public static ISubtaskLogic subtaskLogic;
        static ContainerLogic()
        {
            userLogic = new UserLogic();
            projectLogic = new ProjectLogic();
            taskLogic = new TaskLogic();
            subtaskLogic = new SubtaskLogic();
        }
    }
}
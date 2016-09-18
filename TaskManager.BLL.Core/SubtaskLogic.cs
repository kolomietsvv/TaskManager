using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BLL.Interface;
using TaskManager.DAL.Interface;

namespace TaskManager.BLL.Core
{
    public class SubtaskLogic : ISubtaskLogic
    {
        static ISubtaskDAO subtaskDAO = ContainerDAO.subtaskDAO;
        public void TryToDo(Guid subtaskId, string userLogin)
        {
            subtaskDAO.TryToDo(subtaskId, userLogin);
        }
        public void ConfirmCompletion(Guid subtaskId)
        {
            subtaskDAO.ConfirmCompletion(subtaskId);
        }
        public void RejectCompletion(Guid subtaskId)
        {
            subtaskDAO.RejectCompletion(subtaskId);
        }
    }
}

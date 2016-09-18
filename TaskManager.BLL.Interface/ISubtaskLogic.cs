using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.BLL.Interface
{
    public interface ISubtaskLogic
    {
        void TryToDo(Guid subtaskId, string userLogin);
        void ConfirmCompletion(Guid subtaskId);
        void RejectCompletion(Guid subtaskId);
    }
}

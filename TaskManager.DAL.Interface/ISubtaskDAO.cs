using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DAL.Interface
{
   public interface ISubtaskDAO
    {
        void TryToDo(Guid taskId, string userLogin);
        void ConfirmCompletion(Guid subtaskId);
        void RejectCompletion(Guid subtaskId);
    }
}

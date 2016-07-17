using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common.Entities
{
    class SubTask
    {
       private Guid subtaskId;
       private string name;
       private DateTime creationTime;
       private Guid taskId;
       private bool isDone;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common.Entities
{
    class Task
    {
      private  Guid taskId;
      private  string name;
      private  Guid projectId;
      private  string summary;
      private  DateTime creationTime;
      private  DateTime deadline;
    }
}

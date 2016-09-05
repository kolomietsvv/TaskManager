using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common.Entities
{
    public class ProjectTask
    {
        public Guid TaskId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime Deadline { get; set; }
        
        public ProjectTask(Guid taskId, string name, string summary, DateTime creationTime, DateTime deadline)
        {
            TaskId = taskId;
            Name = name;
            Summary = summary;
            CreationTime = creationTime;
            Deadline = deadline;
        }
        public ProjectTask(Guid taskId, string name, DateTime creationTime, DateTime deadline)
        {
            TaskId = taskId;
            Name = name;
            CreationTime = creationTime;
            Deadline = deadline;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TaskManager.Common.Entities
{
    public class Subtask
    {
        public Guid SubtaskId { get; set; }
        public string Name { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? CompletionTime { get; set; }
        public Guid TaskId { get; set; }
        public string DoneBy { get; set; }
    }
}

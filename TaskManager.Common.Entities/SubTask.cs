using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TaskManager.Common.Entities
{
    public class SubTask
    {
        public Guid SubtaskId { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime CompletionTime { get; set; }
        public Guid TaskId { get; set; }
    }
}

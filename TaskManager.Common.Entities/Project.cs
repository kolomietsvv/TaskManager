using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common.Entities
{
    public class Project
    {
        public Project()
        {

        }
        public Project(Guid id, string name, string summary)
        {
            ProjectId=id;
            Name = name;
            Summary = summary;
        }
        public Project(Guid id, string name)
        {
            ProjectId = id;
            Name = name;
        }

       public Guid ProjectId{get;set;}
       public string Name { get; set; }
       public string Summary { get; set; }
       public string ManagerLogin { get; set; }
    }
}

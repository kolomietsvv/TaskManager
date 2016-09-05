using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskManager.Common.Entities;

namespace TaskManager.PL.WebAPI.Models
{
    public class ProjectModel
    {
        [Required]
        public string ProjectName { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }

         static public void AddProject(string managerLogin, string projectName, string summary)
        {
            ContainerLogic.userLogic.AddProject(managerLogin, projectName, summary);
        }
        static public List<ProjectModel> GetAllProjects(string loginName)//нигде в контроллере не использовать ent
        {
            return ContainerLogic.userLogic.GetAllProjects(loginName)
                .Select(ent => new ProjectModel() { ProjectName = ent.Name, Summary = ent.Summary,  Id=ent.ProjectId.ToString()})
                .ToList();
        }
    }
}
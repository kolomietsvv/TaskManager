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

         static public void AddProject(string managerLogin, string projectName)
        {
            ContainerLogic.userLogic.AddProject(managerLogin, projectName);
        }
        static public List<ProjectModel> GetAllProjects(string loginName)//нигде в контроллере не использовать ent
        {
            return ContainerLogic.userLogic.GetAllProjects(loginName)
                .Select(ent => new ProjectModel() { ProjectName = ent.Name, Summary = ent.Summary })
                .ToList();
        }
    }
}
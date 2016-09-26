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
        public string ManagerLogin { get; set; }
        [Required]
        public string ProjectName{ get; set; }

        public string Summary { get; set; }
        public string Id { get; set; }

        static public Project GetProject(string Id)
        {
            return ContainerLogic.projectLogic.GetProject(Id);
        }
        static public void AddProject(string managerLogin, string projectName, string summary="")
        {
            ContainerLogic.userLogic.AddProject(managerLogin, projectName, summary);
        }
        static public List<ProjectModel> GetAllProjects(string loginName)//нигде в контроллере не использовать ent
        {
            return ContainerLogic.userLogic.GetAllProjects(loginName)
                .Select(ent => new ProjectModel()
                {
                    ManagerLogin = ent.ManagerLogin,
                    ProjectName = ent.Name,
                    Summary = ent.Summary,
                    Id = ent.ProjectId.ToString()
                })
                .ToList();
        }
        static public List<ProjectModel> GetAllLike(ProjectModel request)
        {
            return ContainerLogic.projectLogic.GetAllLike(new Project()
            {
                Name = request.ProjectName,
                Summary = request.Summary,
            })
            .Select(ent => new ProjectModel()
            {
                ProjectName = ent.Name,
                Summary = ent.Summary,
            })
            .ToList();
        }
        static public List<UserModel> GetAllContributors(string projectId)
        {
            return ContainerLogic.projectLogic.GetAllContributors(projectId)
            .Select(ent => new UserModel()
            {
                LoginName = ent.LoginName,
                Email = ent.Email,
                FirstName = ent.FirstName,
                LastName = ent.LastName,
                DateOfBirth = ent.DateOfBirth,
                CompanyName = ent.CompanyName,
                Qualification = ent.Qualification,
                ExtraInf = ent.ExtraInf
            })
            .ToList();
        }
        static public void AddContributor(Guid projectId, string userLogin)
        {
            ContainerLogic.projectLogic.AddContributor(projectId, userLogin);
        }
    }
}
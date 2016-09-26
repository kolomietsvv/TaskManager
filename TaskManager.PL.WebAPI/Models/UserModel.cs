using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Common.Entities;

namespace TaskManager.PL.WebAPI.Models
{
    public class UserModel
    {
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public string Qualification { get; set; }
        public string ExtraInf { get; set; }
        public int Age
        {
            get
            {
                if (DateOfBirth!=null)
                {
                    DateTime now = DateTime.Today;
                    int age = now.Year - DateOfBirth.Value.Year;
                    if (now < DateOfBirth.Value.AddYears(age))
                        age--;
                    return age;
                }
                return 0;
            }
            set { Age = value; }  
        }

        public static void AddRole(string loginName, string roleName)
        {
            ContainerLogic.userLogic.AddRole(loginName, roleName);
        }

        public static void DeleteRole(string loginName, string roleName)
        {
            ContainerLogic.userLogic.DeleteRole(loginName, roleName);
        }

        static public User GetUser(string loginName)
        {
            return ContainerLogic.userLogic.GetUser(loginName);
        }

        static public List<UserModel> GetAllLike(UserModel request)
        {
            return ContainerLogic.userLogic.GetAllLike(new User()
            {
                LoginName = request.LoginName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                CompanyName = request.CompanyName,
                Qualification = request.Qualification,
                ExtraInf = request.ExtraInf
            })
            .Select(ent => new UserModel() {
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
    }
}
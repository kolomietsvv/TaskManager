using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string LoginName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public string Qualification { get; set; }
        public List<Project> Projects { get; set; }
        public string ExtraInf { get; set; }
        public int Age
        {
            get
            {
                if (DateOfBirth != null)
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
    }
}

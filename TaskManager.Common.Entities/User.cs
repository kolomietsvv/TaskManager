using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common.Entities
{
    public class User
    {
        public User()
        {

        }
        public User(string loginName, string passwordHash, string email, List<string> roles)
        {
            LoginName = loginName;
            PasswordHash = passwordHash;
            Email = email;
            Roles = roles;
        }
        public User(Guid userId, string loginName, string passwordHash, string email)
        {
            UserId = userId;
            LoginName = loginName;
            PasswordHash = passwordHash;
            Email = email;
        }

        public User(
            Guid userId, string loginName, string passwordHash,
            string email, string firstName, string lastName, DateTime dateOfBirth,
            string companyName, string qualification, string extraInf, List<string> roles)
        {
            UserId = userId;
            LoginName = loginName;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            CompanyName = companyName;
            Qualification = qualification;
            DateOfBirth = dateOfBirth;
            Email = email;
            Roles = roles;
        }
        public User(
            Guid userId, string loginName, string passwordHash,
            string email, string firstName, string lastName, DateTime dateOfBirth,
            string companyName, string qualification, string extraInf)
        {
            UserId = userId;
            LoginName = loginName;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            CompanyName = companyName;
            Qualification = qualification;
            DateOfBirth = dateOfBirth;
            Email = email;
        }
        public Guid UserId { get; set; }
        public string LoginName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public string Qualification { get; set; }
        public IEnumerable<Guid> ProjectIds { get; set; }
        public string ExtraInf { get; set; }
    }
}

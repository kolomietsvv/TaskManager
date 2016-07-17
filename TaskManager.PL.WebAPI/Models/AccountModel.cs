using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Common.Entities;
using System.Security.Cryptography;
using System.Text;

namespace TaskManager.PL.WebAPI.Models
{
    public class AccountModel
    {
        private static string getHash(string password) {
            var passwordHash = new StringBuilder();
            using (MD5 md5Hash = MD5.Create())
            {
                var hash = md5Hash.ComputeHash(System.Text.Encoding.ASCII.GetBytes(password));
                for (int i = 0; i < hash.Length; i++)
                    passwordHash.Append(hash[i].ToString("X2"));
            }
            return passwordHash.ToString();
        }
        public AccountModel()
        {

        }
        public AccountModel(string login, string password)
        {
            LoginName = login;
            Password = password;
        }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }

        public static User Get(string login)
        {
           return ContainerLogic.userLogic.GetUser(login);
        }
        public static bool CanLogin(string login, string password)
        {
            return ContainerLogic.userLogic.CanLogin(login, getHash(password));
        }
        public static bool CreateNewAccount(string login, string password, string email)
        {
            if (ContainerLogic.userLogic.GetUser(login) == null)
                ContainerLogic.userLogic.AddUser(new User() { LoginName = login, PasswordHash = getHash(password), Email = email });
            else return false;
            return true;
        }
        public static bool CheckToken(string token, string login)
        {
            if (ContainerLogic.userLogic.GetUser(login).UserId.ToString() == token)
                return true;
            return false;
        }
        public static void AddRole(string loginName, string roleName) {
            ContainerLogic.userLogic.AddRole(loginName, roleName);
        }
    }
}
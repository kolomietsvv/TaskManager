using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TaskManager.PL.WebAPI.Models
{
    public class MyRoleProvider: RoleProvider
    {
        public override string[] GetAllRoles()
        {
            return new[] { "Admin", "User", "Manager" };
        }
        public override string[] GetRolesForUser(string username)
        {
            return AccountModel.Get(username).Roles.ToArray();
        }
        #region MyRegion
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion
    }
}
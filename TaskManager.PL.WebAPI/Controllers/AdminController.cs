using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TaskManager.PL.WebAPI.Models;

namespace TaskManager.PL.WebAPI.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        RoleProvider myRoleProvider = new MyRoleProvider();
        [HttpPost]
        [Authorize(Roles = "Manager, Admin")]
        public ActionResult GetAllRoles()
        {
            return Json (new { AllRoles=myRoleProvider.GetAllRoles() });
        }
        [HttpPost]
        [Authorize(Roles = "Manager, Admin")]
        public ActionResult AddRole(string loginName, string roleName)
        {
            UserModel.AddRole(loginName, roleName);
            return new HttpStatusCodeResult(200, "ok");
        }
        [HttpPost]
        [Authorize(Roles = "Manager, Admin")]
        public ActionResult DeleteRole(string loginName, string roleName)
        {
            UserModel.DeletRole(loginName, roleName);
            return new HttpStatusCodeResult(200, "ok");
        }
    }
}

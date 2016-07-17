using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TaskManager.PL.WebAPI.Models;

namespace TaskManager.PL.WebAPI.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)/*можно передать модель с атрибутами [required]*/
        {
            if (ModelState.IsValid)
            {
                if (AccountModel.CanLogin(loginModel.Login, loginModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(loginModel.Login, createPersistentCookie: true);
                    return Json(loginModel);
                }
                return new HttpStatusCodeResult(401, "Wrong login or password");
            }
            return new HttpStatusCodeResult(403, "Invalid Form");
        }

        [HttpPost]
        [Authorize]
        public ActionResult IsAuthorized()
        {
            var user = AccountModel.Get(User.Identity.Name);
            return Json(new AccountModel() { LoginName = user.LoginName, Roles = user.Roles });
        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return new HttpStatusCodeResult(200, "U've been loged out");
        }
        [HttpPost]
        public ActionResult CreateNewAccount(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                if (AccountModel.CreateNewAccount(model.Login, model.Password, model.Email))
                {
                    System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(
                    new System.Net.Mail.MailAddress("kolomiets.victoriya@gmail.com", "Web Registration"),
                    new System.Net.Mail.MailAddress(model.Email));
                    m.Subject = "Email confirmation";
                    m.Body = string.Format("Пройдите по ссылке для подтверждения регистрации <a href=\"{0}\"title=\"User Email Confirm\">{0}</a>",
                        Url.Action("ConfirmRegistration", "Account", new { token = AccountModel.Get(model.Login).UserId, login = model.Login }, Request.Url.Scheme));
                    m.IsBodyHtml = true;
                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                    smtp.Credentials = new System.Net.NetworkCredential("kolomiets.victoriya@gmail.com", "79198308196");
                    //smtp.ServerCertificateValidationCallback = () => true; //Solution for client certificate error
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                    return new HttpStatusCodeResult(200, "User've been created");
                }
                return new HttpStatusCodeResult(403, "User with the same login already exists");
            }
            return new HttpStatusCodeResult(403, "Invalid form");
        }

        [HttpGet]
        //[AllowJsonGet]
        public ActionResult ConfirmRegistration(string token, string login)
        {
            if (AccountModel.CheckToken(token, login))
            {
                FormsAuthentication.SetAuthCookie(login, createPersistentCookie: true);
                AccountModel.AddRole(token, "User");
                return RedirectToAction("Index","Home");
            }
            return new HttpStatusCodeResult(403);
        }
        //todo здесь должен быть метод, возвращающий логин и роли, если пользоатель залогинен
    }
}

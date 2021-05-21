using System;
using System.Web.Mvc;
using GMS.Framework.Contract;
using GMS.Framework.Web;
using GMS.Web.Admin.Common;
using System.Linq;

namespace GMS.Web.Admin.Areas.Account.Controllers
{
    public class AuthController : AdminControllerBase
    {
        [AuthorizeIgnore]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AuthorizeIgnore]
        public ActionResult Login(string username, string password, string verifycode)
        {
            var loginInfo = this.AccountService.Login(username, password);

            if (loginInfo != null)
            {
                this.CookieContext.UserToken = loginInfo.LoginToken;
                this.CookieContext.UserName = loginInfo.LoginName;
                this.CookieContext.UserId = loginInfo.UserID;
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("error", "用户名或密码错误");
                return View();
            }
        }

        [AuthorizeIgnore]
        public ActionResult Logins()
        {
            this.CookieContext.UserToken = Guid.NewGuid();
            this.CookieContext.UserName = "官兵";
            this.CookieContext.UserId = 1;
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            this.AccountService.Logout(this.CookieContext.UserToken);
            this.CookieContext.UserToken = Guid.Empty;
            this.CookieContext.UserName = string.Empty;
            this.CookieContext.UserId = 0;
            return RedirectToAction("Login");
        }

        public ActionResult ModifyPwd()
        {
            var model = this.AccountService.GetUser(123);
            return View(model);
        }

        [HttpPost]
        public ActionResult ModifyPwd(FormCollection collection)
        {
            var model = this.AccountService.GetUser(this.LoginInfo.UserID);
<<<<<<< HEAD
         /*   this.TryUpdateModel<User>(model);*/
=======
            //this.TryUpdateModel<User>(model);
>>>>>>> 7eb0e0dd05bb0efffa25e23fd98430d28faae9a5

            try
            {
                this.AccountService.ModifyPwd(model);
            }
            catch (BusinessException e)
            {
                this.ModelState.AddModelError(e.Name, e.Message);
                return View(model);
            }

            return this.RefreshParent();
        }

        
        public ActionResult Index()
        {
            Popular_recipesEntities popular = new Popular_recipesEntities();
            var li = from p in popular.Cuisine select p;
            return View();
        }
    }
}

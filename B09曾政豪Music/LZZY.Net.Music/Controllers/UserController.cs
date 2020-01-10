using LZZY.Net.Library;
using LZZY.Net.Music.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LZZY.Net.Music.Controllers
{
    public class UserController : Controller
    {
        MusicDbContext db = new MusicDbContext();
        static string returnu = "";

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //登录帐号

        public ActionResult Signin()
        {
            var returnUrl = Request.UrlReferrer;
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Signin(UserViewModel login ,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var member = (from p in db.Users where (p.Email == login.Email && p.Password == login.Password) select p).FirstOrDefault();
                if (member != null)
                {
                    FormsAuthentication.SetAuthCookie(login.Email, false);
                    Session["userrole"] = member.Role.RoleName;
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "账户或密码错误");
                }
            }
            return View();
        }


        //登出
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction ("Index", "Home");
        }

        //注册帐号
        public ActionResult Register()
        {
            //var returnUrl = Request.UrlReferrer;
            //if (returnUrl.ToString().Substring(returnUrl.ToString().LastIndexOf("/")) = "/login")
            //{
            //    returnu = returnUrl.ToString();
            //}
            return View(); 
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var list = MapTo(register);
                db.Users.Add(list);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return PartialView(register);
        }

        private User MapTo(RegisterViewModel register)
        {
            User user = new User();
            user.Email = register.Email;
            user.Password = register.Password;
            user.UserName = register.UserName;
            user.Regtime= DateTime.Now;
            user.RoleId = 1;
            return user;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Many.Models;
using System.Net;
using System.Collections;
using System.Data.Entity;

namespace Many.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        //public ActionResult Index()
        //{
        //    var db = new AccountDbContext();

        //    var rloes = new List<Role>
        //        {
        //            new Role { Name = "我也不知道", Dir = "马马哈哈" },
        //            new Role { Name = "见鬼了", Dir = "啊啊啊啊!！" },
        //            new Role { Name = "哈利路亚", Dir = "哈撒给" }
        //        };
        //    foreach (var a in rloes)
        //    {
        //        db.Roles.Add(a);
        //    }
        //    db.SaveChanges();
        //    return View();
        //}

        public ActionResult Display()
        {
            using (var db = new AccountDbContext())
            {
                var users = db.Users.ToList();
                return View(users);
            }

        }


        public ActionResult Add()       //新增
        {
            return View();
        }

        public ActionResult Part()           //部分视图
        {
            using (var db = new AccountDbContext())
            {
                var roles = db.Roles.ToList();
                return View(roles);
            }
            
        }
        [HttpPost]
        public ActionResult Add(User u)
        {
            using (var db = new AccountDbContext())
            {
                var r = Request.Form["Roles"];
                if (r != null)
                {
                    List<Int32> idList = StringToIntList(r);
                    var role = db.Roles.Where(a => idList.Contains(a.Id)).ToList();
                    foreach (var item in role)
                    {
                        u.Roles.Add(item);
                    }
                    db.Users.Add(u);
                    db.SaveChanges();
                    return RedirectToAction("Display");
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpPost]
        private List<Int32> StringToIntList(string r)
        {
            List<Int32> list = new List<Int32>();
            string[] arr = r.Split(',');
            foreach (var item in arr)
            {
                list.Add(Convert.ToInt32(item));
            }
            return list;
        }


        public ActionResult Edit(int? id)       //编辑
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var db = new AccountDbContext();
            {
                var user = db.Users.Find(id);
                ViewBag.Role = db.Roles.ToList();
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            
        }
        [HttpPost]
        public ActionResult Edit(User u)
        {
            using (var db = new AccountDbContext())
            {
                var r = Request.Form["Roles"];
                if (r != null)
                {
                    List<Int32> Id = StringToIntList(r);
                    var role = db.Roles.Where(a => Id.Contains(a.Id)).ToList();
                    User s = db.Users.Find(u.Id);
                    s.Name = u.Name;
                    s.Password = u.Password;
                    s.RegisterOn = u.RegisterOn;

                    s.Roles.Clear();
                    foreach (var item in role)
                    {
                        s.Roles.Add(item);
                    }
                    db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Display");
                }
                else
                {
                    ViewBag.Role = db.Roles.ToList();
                    var user = db.Users.Find(u.Id);
                    return View(user);
                }
            }
        }


        public ActionResult Detailed(int? id)         //详细
        {
            var db = new AccountDbContext();
            if (id == null)
            {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            
            return View(user);
        }

        public ActionResult Delete(int? id)       //删除
        {
            var db = new AccountDbContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            if (user == null)
            {
                return View(user);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(User user)
        {
            var db = new AccountDbContext();
            if (user.Name!=null)
            {
                db.Entry(user).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Display");
            }
            return View();
        }

    }
}
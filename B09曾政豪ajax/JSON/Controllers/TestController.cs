using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSON.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string userName,string passWord)
        {
            if (userName == "user" && passWord == "123")
            {
                return Content("OK");
            }
            else
            {
                return Content("用户名或密码错误");
            }
        }
        public ActionResult success()
        {
            return View();
        }
    }
}
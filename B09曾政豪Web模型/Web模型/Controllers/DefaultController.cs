using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web模型.Models;

namespace Web模型.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            ViewData["aa"] = "ddd";
            return View();
        }
        public ActionResult GetView()
        {
            Employee el = new Employee();
            el.Name = "韦子雄";
            el.Salary = 8000;
            //ViewData["Employee"] = el;
            return View(el);
        }

    }
}
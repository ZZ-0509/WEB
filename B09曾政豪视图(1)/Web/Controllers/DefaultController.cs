using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index(string emName,int? salary )
        {
            ViewBag.emName = emName;
            ViewBag.salary = salary;
            return View();
        }
    }
}
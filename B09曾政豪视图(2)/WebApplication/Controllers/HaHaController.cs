using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HaHaController : Controller
    {
        // GET: HaHa
        public ActionResult Index(string colorl)
        {
            ViewBag.corol = colorl;
            return View();
        }
    }
}
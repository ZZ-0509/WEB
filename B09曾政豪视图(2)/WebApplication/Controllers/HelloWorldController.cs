using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index( )
        {
            //ViewData["Title"] = "ViewData使用举例";
            //ViewData["StartDate"] = DateTime.Now;
            //ViewData["Price"] = 56;

            //Dictionary<string, string> stackholder = new Dictionary<string, string>();
            //stackholder.Add("吻别", "张学友");
            //stackholder.Add("童年", "罗大佑");
            //ViewData["stackholder"] = stackholder;

            //List<string> modules = new List<string>();
            //modules.Add("管理模块");
            //modules.Add("购物车模块");
            //ViewData["modules"] = modules;

            ViewBag.Title = "ViewData使用举例";
            ViewBag.StartDate = DateTime.Now;
            ViewBag.Price = 56;

            Dictionary<string, string> stackholder = new Dictionary<string, string>();
            stackholder.Add("吻别", "张学友");
            stackholder.Add("童年", "罗大佑");
            ViewBag.stackholder = stackholder;

            List<string> modules = new List<string>();
            modules.Add("管理模块");
            modules.Add("购物车模块");
            ViewBag.modules = modules;
 
            return View();
        }

        public ActionResult TempDataTest()
        {
            ViewData["Title"]="ViewData";
            ViewData["Name"] = "Jone";
            return View();

        }
        public ActionResult ReadTempDatat()

        {
            return View();
        }
    }
}
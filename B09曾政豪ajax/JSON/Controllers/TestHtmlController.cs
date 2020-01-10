using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSON.Controllers
{
    public class TestHtmlController : Controller
    {
        // GET: TestHtml
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pror(string name)
        {
            if (name == "GD")
            {
                var data = new List<string>();
                data.Add("广州");
                data.Add("佛山");
                data.Add("珠海");
                data.Add("深圳");
                data.Add("湛江");
                return PartialView(name, data);
            }
            if (name == "GX")
            {
                var data = new List<string>();
                data.Add("南宁");
                data.Add("柳州");
                data.Add("桂林");
                data.Add("钦州");
                data.Add("防城港");
                return PartialView(name, data);
            }
            return PartialView(name);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web模型.Models;

namespace Web模型.Controllers
{
    public class Default1Controller : Controller
    {
        // GET: Default1
        //public ActionResult Sata(int? plus1,int? plus2)
        //{
        //    Class1 A = new Class1();
        //    A.plus1 = plus1;
        //    A.plus2 = plus2;
        //    A.Result = plus1+plus2;
        //    return View(A);
        //}


        //public ActionResult Sata(Class1 A)
        //{

        //    A.Result = A.plus1 + A.plus2;
        //    return View(A);
        //}


        public ActionResult Sata()
        {
            Class1 A = new Class1();
            return View(A);
        }
        [HttpPost]
        public ActionResult Sata(Class1 A)
        {

            A.Result = A.plus1 + A.plus2;
            return View(A);
        }

    }
}
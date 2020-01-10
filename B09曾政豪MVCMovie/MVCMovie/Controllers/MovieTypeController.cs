using MVCMovie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCMovie.Controllers
{
    public class MovieTypeController : Controller
    {
        MovieDbContext db = new MovieDbContext();
        // GET: MovieType
        public ActionResult Index(/*string searchTitle*/)    //输出数据
        {

            //db.MovieTypes.Add(new MovieType { TypeName = "科幻" });
            //db.MovieTypes.Add(new MovieType { TypeName = "谍战" });
            //db.MovieTypes.Add(new MovieType { TypeName = "动作" });
            //db.SaveChanges();


            var movieType = db.MovieTypes.Select(m => m).ToList();
            //if (searchTitle != null)
            //{
            //    movieType = db.MovieTypes.Where(s => s.TypeName.Contains(searchTitle)).ToList();
            //}

            return View(movieType);


        }

        public ActionResult Add()     //实现新增类型
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(MovieType movieType)
        {
            if (movieType.TypeName != null)
            {
                db.MovieTypes.Add(movieType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)    //根据类型ID更改类型数据
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movieType = db.MovieTypes.Find(id);
            if (movieType == null)
            {
                return View(movieType);
            }
            return View(movieType);
        }
        [HttpPost]

        public ActionResult Edit(MovieType movieType)
        {
            if (movieType.TypeName != null)
            {
                db.Entry(movieType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Eelete(int? id)     //根据类型ID删除类型数据
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movieType = db.MovieTypes.Find(id);
            if (movieType == null)
            {
                return View(movieType);
            }
            return View(movieType);
        }
        [HttpPost]
        public ActionResult Eelete(MovieType movieType)
        {
            if (movieType.TypeName != null)
            {
                db.Entry(movieType).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
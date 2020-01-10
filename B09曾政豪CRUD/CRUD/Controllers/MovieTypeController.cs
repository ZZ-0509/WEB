using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace CRUD.Controllers
{
    public class MovieTypeController : Controller
    {
        MovieDbContext db = new MovieDbContext();
        // GET: MovieType
        public ActionResult Index()
        {
            var movieType = db.MovieTypes.Select(m => m).ToList();
            return View(movieType);
        }
        public ActionResult Create()   //新增
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MovieType movieType)
        {
            if (movieType.TypeName != null)
            {
                db.MovieTypes.Add(movieType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int?id)    //更改
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

        public ActionResult Details(int? id)     //详细
        {
            if (id == 0)
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

        public ActionResult Delete(int? id)    //删除
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
        public ActionResult Delete(int id)
        {

            MovieType movieType = db.MovieTypes.Find(id);
            db.MovieTypes.Remove(movieType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
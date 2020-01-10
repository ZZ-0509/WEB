using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class MovieController : Controller
    {
        MovieDbContext db = new MovieDbContext();
        // GET: Movie
        public ActionResult Index()
        {
            var movies = db.Movies.Select(m => m).ToList();
            return View(movies);
        }
        public ActionResult Create()    //新增
        {
            ViewBag.MovieTypeId = new SelectList(db.MovieTypes, "MovieTypeId", "TypeName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
           
            if (movie != null)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieTypeId = new SelectList(db.MovieTypes, "MovieTypeId", "TypeName");
            return View();
        }

        public ActionResult Details(int id)     //实现详情
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = db.Movies.Find(id);
            if (movie == null)
            {
                return View(movie);
            }
            return View(movie);
        }
        public ActionResult Edit(int? id)         //实现根据ID进行更改
        {
            ViewBag.MovieTypeId = new SelectList(db.MovieTypes, "MovieTypeId", "TypeName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = db.Movies.Find(id);
            if (movie == null)
            {
                return View(movie);
            }
            return View(movie);
        }
        [HttpPost]

        public ActionResult Edit(Movie movie)
        {
            
            if (movie != null)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                var movies = db.Movies.Find(movie.MovieId);
                return View(movies);

        }
        public ActionResult Delete(int? id)         //实现根据ID进行删除
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = db.Movies.Find(id);
            if (movie == null)
            {
                return View(movie);
            }
            return View(movie);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
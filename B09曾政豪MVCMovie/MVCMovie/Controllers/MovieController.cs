using MVCMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace MVCMovie.Controllers
{
    public class MovieController : Controller
    {
        MovieDbContext db = new MovieDbContext();
        // GET: Film
        public ActionResult Index(/*string searchTitle, string MovieTypeId*/)
        {
            ViewBag.MovieTypeId = new SelectList(db.MovieTypes, "MovieTypeId", "TypeName", "");
            var movies = db.Movies.Select(m => m).ToList();
            //if (searchTitle != null)
            //{
            //    movies = movies.Where(s => s.MovieName.Contains(searchTitle)).ToList();
            //}
            //if (!string.IsNullOrEmpty(MovieTypeId))
            //{
            //    movies = movies.Where(s => s.MovieTypeId == Convert.ToInt32(MovieTypeId)).ToList();
            //}
            return View(movies);

        }


        public ActionResult Detailed(int id)     //实现详情
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
            ViewBag.prize = db.Prizes.ToList();
            if (movie == null)
            {
                return View(movie);
            }
            return View(movie);
        }
        [HttpPost]

        public ActionResult Edit(Movie movie)
        {
            var r = Request.Form["Prizes"];
            if (r != null)
            {
                List<Int32> Id = StringToIntList(r);
                var prize = db.Prizes.Where(a => Id.Contains(a.Id)).ToList();
                Movie s = db.Movies.Find(movie.MovieId);
                s.MovieName = movie.MovieName;
                s.Director = movie.Director;
                s.MovieLength = movie.MovieLength;
                s.Time = movie.Time;
                s.Region = movie.Region;
                s.Price = movie.Price;
                s.MovieTypeId = movie.MovieTypeId;

                s.Prizes.Clear();

                foreach (var item in prize)
                {
                    s.Prizes.Add(item);
                }
                db.Entry(s).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Prize = db.Prizes.ToList();
                var movies = db.Movies.Find(movie.MovieId);
                return View(movies);
            }
        }


        public ActionResult Eelete(int? id)         //实现根据ID进行删除
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
        public ActionResult Eelete(Movie movie)
        {
            if (movie.MovieName != null)
            {
                db.Entry(movie).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Add()      //实现新增
        {
            ViewBag.MovieTypeId = new SelectList(db.MovieTypes, "MovieTypeId", "TypeName");
            return View();
        }

        public ActionResult Part()           //部分视图
        {
            using (var db = new MovieDbContext())
            {
                var prizes = db.Prizes.ToList();
                return View(prizes);
            }

        }
        [HttpPost]
        public ActionResult Add(Movie movie)
        {
            var r = Request.Form["Prizes"];
            if (r != null)
            {
                List<Int32> idList = StringToIntList(r);
                var prize = db.Prizes.Where(a => idList.Contains(a.Id)).ToList();
                foreach (var item in prize)
                {
                    movie.Prizes.Add(item);
                }

                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MovieTypeId = new SelectList(db.MovieTypes, "MovieTypeId", "TypeName");
                return View();
            }
        }
        [HttpPost]
        private List<Int32> StringToIntList(string r)
        {
            List<Int32> list = new List<Int32>();
            string[] arr = r.Split(',');
            foreach (var item in arr)
            {
                list.Add(Convert.ToInt32(item));
            }
            return list;
        }
    }
}
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
    public class PrizeController : Controller
    {
        // GET: Prize
        MovieDbContext db = new MovieDbContext();
        public ActionResult Index(/*string searchTitle*/)
        {
            var prize = db.Prizes.ToList();
            //if (searchTitle != null)
            //{
            //    prize = db.Prizes.Where(s => s.Name.Contains(searchTitle)).ToList();
            //}
            return View(prize);
        }

        public ActionResult Add()    //新增
        {
            ViewBag.ID = new SelectList(db.Prizes, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Add(Prize prize)
        {
            if (prize.Name != null)
            {
                db.Prizes.Add(prize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Prizes, "Id", "Name");
            return View();
        }
        public ActionResult Details(int? id)    //详细
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var prize = db.Prizes.Find(id);
            if (prize == null)
            {
                return View(prize);
            }
            return View(prize);
        }

        public ActionResult Edit(int? id)         //编辑
        {
            ViewBag.Id = new SelectList(db.Prizes, "Id", "Name");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var prizes = db.Prizes.Find(id);
            if (prizes == null)
            {
                return View(prizes);
            }
            return View(prizes);
        }
        [HttpPost]

        public ActionResult Edit(Prize prize)
        {
            if (prize.Name != null)
            {
                db.Entry(prize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Eelete(int? id)         //删除
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var prize = db.Prizes.Find(id);
            if (prize == null)
            {
                return View(prize);
            }
            return View(prize);
        }
        [HttpPost]
        public ActionResult Eelete(Prize prize)
        {
            if (prize.Name != null)
            {
                db.Entry(prize).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
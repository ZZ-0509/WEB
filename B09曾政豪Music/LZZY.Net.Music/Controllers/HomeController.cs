using LZZY.Net.Library;
using LZZY.Net.Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LZZY.Net.Music.Controllers
{
    public class HomeController : Controller
    {
        MusicDbContext db = new MusicDbContext();
        public ActionResult Index()
        {
            var list = db.Albums.ToList();

            return View(list);
        }

        public ActionResult About()
        {
            var genres = db.Genres.ToList();
            List<GenreViewModel> list = new List<Models.GenreViewModel>();
            foreach (var item in genres)
            {
                list.Add(MapToModel(item));
            }
            return PartialView(list);
        }

        private GenreViewModel MapToModel(Genre genre)
        {
            GenreViewModel genreViewModel = new GenreViewModel();
            genreViewModel.GenreId = genre.GenreId;
            genreViewModel.GenreName = genre.GenreName;
            return genreViewModel;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult Search(string albumserch)
        {
            var sear = db.Albums.Where(a => a.AlbumName.Contains(albumserch)).ToList().Select(s=>new { s.AlbumName,s.Price,s.Website,s.AlbumId});
            return Json(sear);
        }
    }
}
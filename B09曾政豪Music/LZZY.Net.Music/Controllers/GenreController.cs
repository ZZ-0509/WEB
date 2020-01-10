using LZZY.Net.Library;
using LZZY.Net.Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LZZY.Net.Music.Controllers
{
    /// <summary>
    /// 左半边导航
    /// </summary>
    public class GenreController : Controller
    {
        MusicDbContext db = new MusicDbContext();
        // GET: Genre
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GewnreMenu()
        {
            var genres = db.Genres.ToList();
            List<GenreViewModel> list = new List<Models.GenreViewModel>();
            foreach(var item in genres)
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

        public ActionResult Display(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var genreModel = db.Genres.Find(id);
            if (genreModel == null)
            {
                return HttpNotFound();
            }
            List<AlbumViewModel> list = new List<AlbumViewModel>();
            foreach(var item in genreModel.Albums)
            {
                list.Add(MapToModel(item));
            }
            return PartialView(list);
        }
        private AlbumViewModel MapToModel(Album album)
        {
            AlbumViewModel albumViewModel = new AlbumViewModel();
            albumViewModel.AlbumId = album.AlbumId;
            albumViewModel.AlbumName = album.AlbumName;
            albumViewModel.Price = album.Price;
            albumViewModel.ShelfTime = album.ShelfTime;
            albumViewModel.GenreName = album.Genre.GenreName;
            albumViewModel.SingerName = album.Singer.SingerName;
            albumViewModel.Website = album.Website;
            return albumViewModel;
        }


        public ActionResult Link(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(MapToModel(album));

        }

    }
}
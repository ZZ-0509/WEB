using LZZY.Net.Library;
using LZZY.Net.Music.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LZZY.Net.Music.Controllers
{
    public class AlbumListController : Controller
    {
        MusicDbContext db = new MusicDbContext();
        private readonly string filepath;

        // GET: AlbumList
        public ActionResult Index()
        {
            var albums = db.Albums.Select(m => m).ToList();
            //var albums = db.Albums.ToList();
            List<AlbumListViewModel> list = new List<AlbumListViewModel>();
            foreach(var item in albums)
            {
                list.Add(AlbumList(item));
            }
            return PartialView(list);
        }
        /// <summary>
        /// 将Model数据转化为ViewModel数据
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        private AlbumListViewModel AlbumList(Album album)
        {
            AlbumListViewModel albumListViewModel = new AlbumListViewModel();
            albumListViewModel.AlbumId = album.AlbumId;
            albumListViewModel.AlbumName = album.AlbumName;
            albumListViewModel.GenreId = album.GenreId;
            albumListViewModel.Price =album.Price;
            albumListViewModel.ShelfTime = album.ShelfTime;
            albumListViewModel.SingerId = album.SingerId;
            albumListViewModel.Website = album.Website;
            return albumListViewModel;
        }
        /// <summary>
        /// 实现详细
        /// </summary>
        /// <returns></returns>
        public ActionResult Detailed(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var album = db.Albums.Find(id);
            if (album == null)
            {
                return View(album);
            }
            return View(AlbumList(album));
        }
        /// <summary>
        /// 实现删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var album = db.Albums.Find(id);
            if (System.IO.File.Exists(Server.MapPath(album.Website)))
                System.IO.File.Delete(Server.MapPath(album.Website));
            if (album == null)
            {
                return View(album);
            }
            return View(AlbumList(album));
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 实现新增
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()    
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName");
            ViewBag.SingerId = new SelectList(db.Singers, "SingerId", "SingerName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(AlbumListViewModel albumlist)
        {

            if (ModelState.IsValid)
            {
                Album album =MapToAlbum(albumlist);

                var file = Request.Files["fileupload"];
                string fileName = file.FileName;
                if (!(string.IsNullOrEmpty(fileName) || (file.ContentLength == 00)))
                {
                    if (file.ContentLength > 0 && file.ContentLength <= 2097152)
                    {
                        string hz = file.FileName.Substring(file.FileName.LastIndexOf(','));
                        if (IsImage(hz))
                        {
                            string uploadPath = "/content/images";
                            string filename = Guid.NewGuid().ToString("N") + hz;
                            string filenath = Server.MapPath(uploadPath);
                            if (!Directory.Exists(filepath))
                            {
                                Directory.CreateDirectory(filepath);
                            }
                            file.SaveAs(Path.Combine(filepath, filename));
                            album.Website = uploadPath + filename;
                            db.Albums.Add(album);
                            db.SaveChanges();
                            return Redirect("Index");
                        }
                        else
                            ViewBag.error = "上传文件必须是如下图片类型：jpg,gif,pan,bmp";
                    }
                    else
                        ViewBag.error = "图片文件大小越界：0~2M字节";
                }
                {
                    db.Albums.Add(album);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }
            else
            {
                ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName");
                ViewBag.SingerId = new SelectList(db.Singers, "SingerId", "SingerName");
            }
            return View();
        }

        private bool IsImage(string hz)
        {
            string[] hzs = { ".JPG", ".GIF", ".PNG", ".BMP" };
            bool ys = false;
            hz = hz.ToUpper();
            foreach(string s in hzs)
            {
                if (s == hz)
                {
                    ys = true;
                    break;
                }
            }
            return ys;
        }

        private Album MapToAlbum(AlbumListViewModel albumlist)
        {
            Album album = new Album();
            album.AlbumId = albumlist.AlbumId;
            album.AlbumName = albumlist.AlbumName;
            album.GenreId = albumlist.GenreId;
            album.Price = albumlist.Price;
            album.ShelfTime= DateTime.Now;
            album.SingerId = albumlist.SingerId;
            album.Website = albumlist.Website;
            return album;
        }

        public ActionResult Edit(int? id)
        {
            Album album = db.Albums.Find(id);
            AlbumListViewModel albumlist = new AlbumListViewModel();
            albumlist.Genres = new SelectList(db.Genres, "GenreId", "GenreName",albumlist.GenreId);
            albumlist.Genres = new SelectList(db.Singers, "SingerId", "SingerName",albumlist.SingerId);

            List<AlbumListViewModel> list = new List<AlbumListViewModel>();
            return View(AlbumList(album));
        }
        [HttpPost]
        public ActionResult Edit(AlbumListViewModel albumlist)
        {

            if (albumlist != null)
            {
                Album album = MapToAlbumEdit(albumlist);
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
              else
            {
                albumlist.Genres = new SelectList(db.Genres, "GenreId", "GenreName", albumlist.GenreId);
                albumlist.Genres = new SelectList(db.Singers, "SingerId", "SingerName", albumlist.SingerId);
            }
            var albums = db.Albums.Find(albumlist.AlbumId);
            return View(albums);

        }
        private Album MapToAlbumEdit(AlbumListViewModel albumlist)
        {
            Album album = new Album();
            album.AlbumId = albumlist.AlbumId;
            album.AlbumName = albumlist.AlbumName;
            album.GenreId = albumlist.GenreId;
            album.Price = albumlist.Price;
            album.ShelfTime = albumlist.ShelfTime;
            album.SingerId = albumlist.SingerId;
            album.Website = albumlist.Website;   
            return album;
        }
    }
   
}
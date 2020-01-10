using LZZY.Net.Library;
using LZZY.Net.Music.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LZZY.Net.Music.Controllers
{
    [Authorize]
    public class ManagController : Controller
    {
        MusicDbContext db = new MusicDbContext();
        // GET: GenreManag

        /// <summary>
        /// 流派管理
        /// </summary>
        /// <returns></returns>
        public ActionResult GenreIndex()
        {
            var genres = db.Genres.ToList();
            List<ManagViewModel> list = new List<Models.ManagViewModel>();
            foreach (var item in genres)
            {
                list.Add(MapToModel(item));
            }
            return PartialView(list);
        }
        public ActionResult GenreCreate()    //流派新增
        {
            return View();
        }
        [HttpPost]
        public ActionResult GenreCreate(ManagViewModel Manag)
        {
            Genre genre = MapTo(Manag);
            if (Manag != null)
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return RedirectToAction("GenreIndex");
            }
            return View();
        }
        public ActionResult GenreDelete(int? id)         //流派删除
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var genre = db.Genres.Find(id);
            if (genre == null)
            {
                return View(genre);
            }
            return View(MapToModel(genre));
        }
        [HttpPost]
        public ActionResult GenreDelete(int id)
        {

            Genre genre = db.Genres.Find(id);
            db.Genres.Remove(genre);
            db.SaveChanges();
            return RedirectToAction("GenreIndex");
        }

        public ActionResult GenreEdit(int? id)           //流派编辑
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var genre = db.Genres.Find(id);
            if (genre == null)
            {
                return View(genre);
            }
            return View(MapToModel(genre));
        }
        [HttpPost]
        public ActionResult GenreEdit(ManagViewModel Manag)
        {
            if (Manag != null)
            {
                Genre genre = MapTo(Manag);
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GenreIndex");
            }
            var genres = db.Genres.Find(Manag.GenreId);
            //return View(GenreManag);
            return RedirectToAction("GenreIndex");
        }

        // 流派Model转ViewModel
        private ManagViewModel MapToModel(Genre genre)
        {
            ManagViewModel Manag = new ManagViewModel();
            Manag.GenreId = genre.GenreId;
            Manag.Describe = genre.Describe;
            Manag.GenreName = genre.GenreName;
            return Manag;
        }
        // 流派ViewModel转Model
        private Genre MapTo(ManagViewModel genreManag)
        {
            Genre genre = new Genre();
            genre.GenreId = genreManag.GenreId;
            genre.Describe = genreManag.Describe;
            genre.GenreName = genreManag.GenreName;
            return genre;
        }


        /// <summary>
        /// 歌手管理
        /// </summary>
        /// <returns></returns>
        public ActionResult SingerIndex()
        {
            var singers = db.Singers.ToList();
            List<ManagViewModel> list = new List<Models.ManagViewModel>();
            foreach (var item in singers)
            {
                list.Add(Singer(item));
            }
            return PartialView(list);
        }
        public ActionResult SingerCreate()        //歌手新增
        {
            return View();
        }
        [HttpPost]
        public ActionResult SingerCreate(ManagViewModel Manag)
        {
            Singer singer = singerMod(Manag);
            if (Manag != null)
            {
                db.Singers.Add(singer);
                db.SaveChanges();
                return RedirectToAction("SingerIndex");
            }
            return View();
        }
        public ActionResult SingerDelete(int? id)         //歌手删除
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var singer = db.Singers.Find(id);
            if (singer == null)
            {
                return View(singer);
            }
            return View(Singer(singer));
        }
        [HttpPost]
        public ActionResult SingerDelete(int id)
        {

            Singer singer = db.Singers.Find(id);
            db.Singers.Remove(singer);
            db.SaveChanges();
            return RedirectToAction("SingerIndex");
        }
        public ActionResult SingerDetails(int? id)           //歌手详细
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var singer = db.Singers.Find(id);
            if (singer == null)
            {
                return View(singer);
            }
            return View(Singer(singer));
        }
        public ActionResult SingerEdit(int? id)           //歌手编辑
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var singer = db.Singers.Find(id);
            if (singer == null)
            {
                return View(singer);
            }
            return View(Singer(singer));
        }
        [HttpPost]
        public ActionResult SingerEdit(ManagViewModel Manag)       
        {
            if (Manag != null)
            {
                Singer singer = singerMod(Manag);
                db.Entry(singer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SingerIndex");
            }
            return RedirectToAction("SingerIndex");
        }




        // 歌手ViewModel转Model

        private Singer singerMod(ManagViewModel Manag)
        {
            Singer singer = new Singer();
            singer.SingerId = Manag.SingerId;
            singer.SingerName = Manag.SingerName;
            singer.Gender = Manag.Gender;
            singer.Introduce = Manag.Introduce;
            return singer;
        }
        //歌手Model转ViewModel
        private ManagViewModel Singer(Singer singer)
        {
            ManagViewModel Manag = new ManagViewModel();
            Manag.SingerId = singer.SingerId;
            Manag.SingerName = singer.SingerName;
            Manag.Gender = singer.Gender;
            Manag.Introduce = singer.Introduce;
            return Manag;
        }




        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        public ActionResult UserIndex()
        {
            var user = db.Users.ToList();
            List<ManagViewModel> list = new List<Models.ManagViewModel>();
            foreach (var item in user)
            {
                list.Add(UserModel(item));
            }
            return PartialView(list);
        }
        public ActionResult UserCreate()        //用户新增
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserCreate(ManagViewModel Manag)
        {
            User user = UserView(Manag);
            if (Manag != null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("UserIndex");
            }
            return View();
        }
        public ActionResult UserDelete(int? id)         //用户删除
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            if (user == null)
            {
                return View(user);
            }
            return View(UserModel(user));
        }
        [HttpPost]
        public ActionResult UserDelete(int id)
        {

            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("UserIndex");
        }
        public ActionResult Initial(int? id)           //用户密码初始化
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            if (user == null)
            {
                return View(user);
            }
            return View(UserModel(user));
        }
        [HttpPost]
        public ActionResult Initial(ManagViewModel Manag)
        {
            if (Manag != null)
            {
     
                User user = InitialModel(Manag);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserIndex");
            }
            return RedirectToAction("UserIndex");
        }
        private User InitialModel(ManagViewModel Manag)
        {
            User user = new User();
            user.UserId = Manag.UserId;
            user.RoleId = 1;
            user.Email = Manag.Email;
            user.Password = "123456";
            user.UserName = Manag.UserName;
            user.Regtime = Manag.Regtime;
            return user;
        }
        //用户ViewModel转Model
        private User UserView(ManagViewModel Manag)
        {
            User user = new User();
            user.UserId = Manag.UserId;
            user.RoleId = 1;
            user.Email = Manag.Email;
            user.Password = Manag.Password;
            user.UserName = Manag.UserName;
            user.Regtime = DateTime.Now;
            return user;
        }

        //用户Model转ViewModel
        private ManagViewModel UserModel(User user)
        {
            ManagViewModel Manag = new ManagViewModel();
            Manag.UserId = user.UserId;
            Manag.Email = user.Email;
            Manag.Password = user.Password;
            Manag.UserName = user.UserName;
            Manag.Regtime = user.Regtime;
            return Manag;
        }
    }
}

using LZZY.Net.Library;
using LZZY.Net.Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LZZY.Net.Music.Controllers
{
    public class OrderController : Controller
    {
        MusicDbContext db = new MusicDbContext();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddOrder()
        {
            var carts = db.Carts.Where(s => s.UserName == User.Identity.Name).ToList();
            decimal? totalPrice = 0.0M;
            if (carts.Count != 0)
            {
                foreach (var item in carts)
                {
                    totalPrice += item.Quantity * item.Album.Price;
                }
            }
            BuyViewMode buyview = new Models.BuyViewMode();
            buyview.CsorderDetails = new List<CsorderDetail>();
            foreach(var item in carts)
            {
                var detail = new CsorderDetail();
                detail.AlbumId = item.AlbumId;
                detail.Album = db.Albums.Find(item.AlbumId);
                detail.Quantity = item.Quantity;
                detail.Price = item.Album.Price;
                

                buyview.CsorderDetails.Add(detail);
            }
            buyview.Total = totalPrice??0.0M;
            return View(buyview);
        }
        [HttpPost]
        public ActionResult AddOrder(BuyViewMode buyview)
        {
            Order order = new Order();
            //order = MaPtoOrderModel(buyview);
            //order.UserName = User.Identity.Name;
            //order.OrderDate = DateTime.Now;
            return View();
        }
        private BuyViewMode AlbumList(Order order)
        {
            BuyViewMode buyViewMode = new BuyViewMode();
            buyViewMode.OrderName = order.OrderName;
            buyViewMode.Addressee = order.Addressee;
            buyViewMode.Country = order.Country;
            buyViewMode.Province = order.Province;
            buyViewMode.City = order.City;
            buyViewMode.Address = order.Address;
            buyViewMode.ZipCode = order.ZipCode;
            buyViewMode.Phone = order.Phone;
            buyViewMode.Total = order.Total;
            buyViewMode.OrderTime = DateTime.Now;
            return buyViewMode;
        }
    }
}
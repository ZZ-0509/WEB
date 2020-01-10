using LZZY.Net.Library;
using LZZY.Net.Music.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LZZY.Net.Music.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        MusicDbContext db = new MusicDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            var carts = db.Carts.Where(s => s.UserName == User.Identity.Name).ToList();
            decimal? totalPrice = 0.0M;
            if (carts.Count!= 0)
            {
                foreach (var item in carts)
                {
                    totalPrice += item.Quantity * item.Album.Price;
                }
            }
            var carViewModel= new CartViewModel();
            {
                carViewModel.CartItems = carts;
                carViewModel.CartTotal = totalPrice ?? decimal.Zero;
            }
            return View(carViewModel);
        }
        public ActionResult AddToCart(int id)
        {
            var messgae = "";
            var cartItem = db.Carts.SingleOrDefault(c => c.AlbumId == id && c.UserName == User.Identity.Name);
            if (cartItem == null)
            {
                cartItem = new Cart()
                {
                    AlbumId = id,
                    UserName = User.Identity.Name,
                    Quantity = 1,
                    Date = DateTime.Now
                };
                db.Carts.Add(cartItem);
                db.SaveChanges();
                messgae="添加"+db.Albums.Find(id).AlbumName+"成功";
            }
            else
            {
                cartItem.Quantity++;
                db.Entry(cartItem).State = EntityState.Modified;
                db.SaveChanges();
                messgae = db.Albums.Find(id).AlbumName + "数量成功加+1";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Remove(int id)
        {
            var CartItem = db.Carts.Find(id);
            if (CartItem.Quantity > 1)
            {
                CartItem.Quantity--;
            }
            else
            {
                db.Carts.Remove(CartItem);
            }
            db.SaveChanges();
            var carts = db.Carts.Where(s => s.UserName == User.Identity.Name).ToList();
            decimal? totalPrice = 0.0M;
            if (carts.Count != 0)
            {
                foreach (var item in carts)
                {
                    totalPrice += item.Quantity * item.Album.Price;
                }
            }
            var htmlString = "";
            foreach (var item in carts)
            {


                htmlString += "<tr>";
                htmlString += "<td><a href='../Detailed/AlbumList/ + item.CartId'> + </a></td>";
                htmlString += "";
            }
            return Json("");
        }
        public ActionResult TotalCart()
        {
            var cart = db.Carts.Where(c => c.UserName == User.Identity.Name).ToList();
            int? total = 0;
            foreach(var item in cart)
            {
                total += item.Quantity;
            }
            ViewData["Totalcart"] = total;
            return PartialView();
        }
    }
}
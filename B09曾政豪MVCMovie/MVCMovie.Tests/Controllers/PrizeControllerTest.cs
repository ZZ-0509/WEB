using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCMovie.Models;
using MVCMovie.Controllers;
using System.Web.Mvc;
using System.Linq;

namespace MVCMovie.Tests.Controllers
{
    [TestClass]
    public class PrizeControllerTest
    {
        PrizeController controller = new PrizeController();
        MovieDbContext db = new MovieDbContext();
        [TestMethod]
        public void Index()
        {
            var expectioncout = 2;
            var indexActionResult = controller.Index() as ViewResult;
            var actualCount = indexActionResult.ViewData.Model as System.Collections.Generic.List<Prize>;
            Assert.AreEqual(expectioncout, actualCount.Count);
            Assert.IsNotNull(indexActionResult);
        }
        [TestMethod]
        public void Add()    //新增
        {
            var result = controller.Add() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void AddMovieType()    //新增
        {
            Prize prize = new Prize() { Name = "金狮奖",Period="2018-09-21", Sponsor ="威尼斯国际电影节"};
            var result = controller.Add(prize) as RedirectToRouteResult;
            var addItem = db.Prizes.Where(t => t.Name == "金狮奖");
            Assert.AreEqual(1, addItem.Count());
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        [TestMethod]
        public void Edit()   //找出要更改的值
        {
            var editResult = controller.Edit(3) as ViewResult;
            Assert.IsNotNull(editResult);
            var actionResult = (Prize)editResult.Model;
            Assert.AreEqual("金马奖", actionResult.Name);
        }
        [TestMethod]
        public void Eelete()   //找出要删除的值
        {
            var editResult = controller.Edit(2) as ViewResult;
            Assert.IsNotNull(editResult);
            var actionResult = (Prize)editResult.Model;
            Assert.AreEqual("奥斯卡小金人", actionResult.Name);
        }
    }
}

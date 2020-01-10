using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCMovie.Controllers;
using MVCMovie.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVCMovie.Tests.Controllers
{
    [TestClass]
    public class MovieTypeControllerTest
    {
        MovieTypeController controller = new MovieTypeController();
        MovieDbContext db = new MovieDbContext();

        [TestMethod]
        public void Index()   
        {
            var expectioncout = 3;
            var indexActionResult = controller.Index() as ViewResult;
            var actualCount = indexActionResult.ViewData.Model as System.Collections.Generic.List<MovieType>;
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
            MovieType morieType = new MovieType() { TypeName = "警匪" };
            var result = controller.Add(morieType) as RedirectToRouteResult;
            var addItem = db.MovieTypes.Where(t => t.TypeName == "警匪");
            Assert.AreEqual(1, addItem.Count());
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        [TestMethod]
        public void Edit()   //找出要更改的值
        {
            var editResult = controller.Edit(1) as ViewResult;
            Assert.IsNotNull(editResult);
            var actionResult = (MovieType)editResult.Model;
            Assert.AreEqual("科幻",actionResult.TypeName);
        }
        [TestMethod]
        public void EditMovieType()   //进行更改
        {
            //找出一条记录
            var editResult = controller.Edit(5) as ViewResult;
            var model = (MovieType)editResult.Model;
            //修改该记录的数据
            model.TypeName = "哼哈二将";
            var actionResult = controller.Edit(model);
            //进行比较
            var editItem = db.MovieTypes.Where(t => t.TypeName == "哼哈二将");

        }
        [TestMethod]
        public void Eelete()   //找出要删除的值
        {
            var editResult = controller.Edit(1) as ViewResult;
            Assert.IsNotNull(editResult);
            var actionResult = (MovieType)editResult.Model;
            Assert.AreEqual("科幻", actionResult.TypeName);
        }
        [TestMethod]
        public void EeleteMovieType()    //实行删除
        {
            //找出一条记录
            var editResult = controller.Edit(1) as ViewResult;
            var model = (MovieType)editResult.Model;
            //删除该记录的数据
            model.TypeName = "科幻";
            var actionResult = controller.Edit(model);
            var Edit = db.MovieTypes.Where(t => t.TypeName == "科幻");
            Assert.AreEqual(1, Edit.Count());
        }
    }
}

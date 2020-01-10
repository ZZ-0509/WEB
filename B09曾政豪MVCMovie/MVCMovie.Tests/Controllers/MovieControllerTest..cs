using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCMovie.Controllers;
using MVCMovie.Models;
using System.Web.Mvc;
using System.Linq;

namespace MVCMovie.Tests.Controllers
{
    [TestClass]
    public class MovieControllerTest
    {
        MovieController controller = new MovieController();
        MovieDbContext db = new MovieDbContext();
        [TestMethod]
             public void Index()
        {
            var expectioncout = 1;
            var indexActionResult = controller.Index() as ViewResult;
            var actualCount = indexActionResult.ViewData.Model as System.Collections.Generic.List<Movie>;
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
        public void Edit()   //找出要更改的值
        {
            var editResult = controller.Edit(1) as ViewResult;
            Assert.IsNotNull(editResult);
            var actionResult = (Movie)editResult.Model;
            Assert.AreEqual("一个人的武林", actionResult.MovieName);
        }
        [TestMethod]
        public void Eelete()   //找出要删除的值
        {
            var editResult = controller.Edit(1) as ViewResult;
            Assert.IsNotNull(editResult);
            var actionResult = (Movie)editResult.Model;
            Assert.AreEqual("一个人的武林", actionResult.MovieName);
        }
    }
}

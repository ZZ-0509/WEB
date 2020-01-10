using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCMovie.Models;

namespace MVCMovie.Tests
{
    [TestClass]
    public class EFTest
    {
        [TestMethod]
        public void TestEF()
        {
            var db = new MovieDbContext();
            Movie a = new Movie() { MovieName = "沙雕" };
            db.Movies.Add(a);
            db.SaveChanges();
            
        }
    }
}

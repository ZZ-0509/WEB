using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class MovieDbInitializer:DropCreateDatabaseIfModelChanges<MovieDbContext>
    {
        protected override void Seed(MovieDbContext db)
        {
            db.MovieTypes.Add(new MovieType { TypeName = "动作" });
            db.Movies.Add(new Movie { MovieName = "流浪地球", Time = Convert.ToDateTime("2019-2-21"), Region = "中国", movieType = new MovieType { TypeName = "科幻" } });
            base.Seed(db);
        }
    }
}
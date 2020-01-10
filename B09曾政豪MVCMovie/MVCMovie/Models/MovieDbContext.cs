using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCMovie.Models
{
    public class MovieDbContext: DbContext
    {
        public DbSet<MovieType> MovieTypes { set; get; }
        public DbSet<Movie> Movies { set; get; }
        public DbSet<Prize> Prizes { set; get; }
        
    }
}
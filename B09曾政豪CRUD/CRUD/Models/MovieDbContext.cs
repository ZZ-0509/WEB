using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class MovieDbContext : DbContext
    {
        public DbSet<MovieType> MovieTypes { set; get; }
        public DbSet<Movie> Movies { set; get; }


    }
}
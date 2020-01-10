using EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class BlogDbContext: DbContext
    {
        public DbSet<BlogUser> BlogUsers { set; get; }
        public DbSet<Post> Posts { set; get; }
    }
}

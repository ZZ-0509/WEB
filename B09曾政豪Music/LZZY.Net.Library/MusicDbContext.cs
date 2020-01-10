using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZZY.Net.Library
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Album> Albums { set; get; }
        public DbSet<Genre> Genres { set; get; }
        public DbSet<Singer> Singers { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<Role> Roles { set; get; }
        public DbSet<Cart> Carts { set; get; }
        public DbSet<CsorderDetail> CsorderDetails { set; get; }
        public DbSet<Order> Orders { set; get; }
    }
}

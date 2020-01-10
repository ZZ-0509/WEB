using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Many.Models
{
    public class AccountDbContext: DbContext
    {
        public virtual DbSet<Role> Roles { set; get; }
        public virtual DbSet<User> Users { set; get; }
    }
}
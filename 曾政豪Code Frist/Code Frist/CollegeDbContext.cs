using CodeFrist.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFrist
{
    public class CollegeDbContext: DbContext   //学院的系统上下文
    {
        public DbSet<Course> Courses { set; get; }
        public DbSet<Department> Departments { set; get; }
    }
}

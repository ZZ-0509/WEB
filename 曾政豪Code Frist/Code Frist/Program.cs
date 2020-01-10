using CodeFrist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFrist
{
    class Program
    {

        static CollegeDbContext db = new CollegeDbContext();
        static void Main(string[] args)
        {
            CollegeDbContext db = new CollegeDbContext();

            //添加学院信息
            //Department a = new Department();
            //a.Sdept = "环境与食品安全学院";
            //a.Dean = "李";
            //db.Departments.Add(a);
            //db.SaveChanges();

            //添加课程信息
            //Course a = new Course();
            //a.CourseName = "WED";
            //a.Credit = 12;
            //a.DepartmentId = 1;
            //db.Courses.Add(a);
            //db.SaveChanges();

            //A();
            //C();
            //S(12);
            XF();
            //Xi(1);
            //Ke("语文");
            //Shan(17);
            //Xiugai(8, "语文");

            Console.Read();
        }
        //public static void A()
        //{
        //    var query = db.Courses.Select(b => new { b.CourseName });
        //    foreach (var item in query)
        //    {
        //        Console.WriteLine("课程有:{0}", item.CourseName);
        //    }
        //}

        //public static void C()
        //{
        //    var query = db.Courses.Join(db.Departments, b => b.DepartmentId, j => j.DepartmentId, (b, p) => new { b.CourseName, p.Sdept });
        //    foreach (var item in query)
        //    {
        //        Console.WriteLine("{0}有:{1}课  ",item.Sdept,item.CourseName);
        //    }

        //}

        //public static void S(int id)
        //{
        //    var query = db.Courses.Where(b => b.Credit == id).Select(b => b);
        //    foreach (var item in query)
        //    {
        //        Console.WriteLine("{0}", item.CourseName);
        //    }
        //}

        public static void XF()
        {
            var query = db.Courses.Where(b =>b.Credit<10).Select(b => b);
            foreach (var item in query)
            {
                Console.WriteLine("{0}", item.CourseName);
                
            }
        }

        //public static void Xi(int id)
        //{
        //    var query = db.Courses.Where(b => b.DepartmentId == id).Select(b => b);
        //    foreach (var item in query)
        //    {
        //        Console.WriteLine("{0}", item.CourseName);
        //    }
        //}
        //public static void Ke(string name)
        //{
        //    var query = db.Courses.Join(db.Departments, b => b.DepartmentId, j => j.DepartmentId, (b, p) => new { b.CourseName, b.Credit, p.Sdept }).Where(b=>b.CourseName==name);
        //    foreach (var item in query)
        //    {
        //        Console.WriteLine("学院：{0} \t {1}课 \t 有：{2}学分  ", item.Sdept, item.CourseName,item.Credit);
        //    }
        //}


        //public static void Shan(int id)
        //{
        //    var qu = db.Courses.Find(id);
        //    db.Courses.Remove(qu);
        //    db.SaveChanges();
        //    Console.WriteLine("删除成功！");
        //}

        //public static void Xiugai(int id, string newname)
        //{
        //    var a = (db.Courses.Where(b => b.CourseId == id).Select(b => b)).First();
        //    a.CourseName = newname;
        //    db.SaveChanges();
        //    Console.WriteLine("更新成功！");
        //}


    }
}

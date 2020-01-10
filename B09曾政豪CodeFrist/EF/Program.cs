using EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Program
    {
        static BlogDbContext db = new BlogDbContext();
        static void Main(string[] args)
        {
            //添加一个新博客名
            Console.WriteLine("请输入一个博客名:");
            string name = Console.ReadLine();
            BlogUser blog = new BlogUser();
            blog.BlogName = name;
            AddBlogUser(blog);

            //查询所有博客名
            //var qList = GetAllG();
            //foreach (var item in qList)
            //{
            //    Console.WriteLine(item.BlogName);
            //}

            //根据博客id修改博客名
            //Console.WriteLine("请输入要更改的博客ID:");
            //int id = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("请输入新的博客名:");
            //string name = Console.ReadLine();
            //UpdateBlogUser(id, name);

            //根据博客id删除博客名
            //Console.WriteLine("请输入要更改的博客ID:");
            //int id = Convert.ToInt32(Console.ReadLine());
            //DeleteBlogUser(id);

            Console.Read();
        }
        //添加一个新博客名
        public static void AddBlogUser(BlogUser blog)
        {
            db.BlogUsers.Add(blog);
            db.SaveChanges();
            Console.WriteLine("OK");
        }

        ////查询所有博客名
        //public static List<BlogUser> GetAllG()
        //{
        //    var queryList = db.BlogUsers.Select(g => g);
        //    return queryList.ToList();
        //}

        ////根据博客id修改博客名
        //public static void UpdateBlogUser(int id,string newName)
        //{

        //    var query = db.BlogUsers.Where(b => b.BlogUserID.Equals(id)).Select(b => b).First();
        //    query.BlogName = newName;
        //    db.SaveChanges();
        //    Console.WriteLine("ok");
        //}

        ////根据博客id删除博客名
        //public static void DeleteBlogUser(int id)
        //{
        //    var query = db.BlogUsers.Find(id);
        //    db.BlogUsers.Remove(query);
        //    db.SaveChanges();
        //    Console.WriteLine("OK");
        //}
    
    }
}

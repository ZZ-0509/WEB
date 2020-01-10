using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = new int[] { 1, 3, 5, 7, 9, 11, 13, 15 };

            //Linq方法
            //var numQuery = from num in number
            //               where num % 3 == 0        //求余函数
            //               orderby num descending   //降序
            //               select num;

            //Lambda方法
            //var numQuery = number
            //    .Where(s => s % 3 == 0)
            //    .OrderByDescending(p => p)
            //    .Select(p => p);
            //foreach (int n in numQuery)  //执行查询
            //{
            //    Console.Write(n + "\t");
            //}
            //Console.ReadLine();

            List<Class> ClassList = new List<Class>()
        {
            new Class() {Id=1,ClassName="初班" },
            new Class() {Id=2,ClassName="中班" },
            new Class() {Id=3,ClassName="高班" },
            new Class() {Id=4,ClassName="大班" },
        };
            List<Student> Students = new List<Student>()
        {
            new Student() {Name="曾政豪",Id="20180310140",Age=20,ClassId=1 },
            new Student() {Name="韦子熊",Id="20180310148",Age=19,ClassId=1 },
            new Student() {Name="张三",Id="20180310141",Age=26,ClassId=2 },
            new Student() {Name="李四",Id="20180310142",Age=31,ClassId=3 },
            new Student() {Name="李明",Id="20180310143",Age=23,ClassId=4 },
            new Student() {Name="王明",Id="20180310144",Age=33,ClassId=1 },
            new Student() {Name="王阳",Id="20180310145",Age=24,ClassId=2 },
            new Student() {Name="武久",Id="20180310146",Age=18,ClassId=3 },
            new Student() {Name="氧乐多",Id="20180310147",Age=26,ClassId=4 },
            new Student() {Name="小七",Id="20180310148",Age=24,ClassId=1 },
            new Student() {Name="小八",Id="20180310149",Age=32,ClassId=2 },
            new Student() {Name="小九",Id="20180310150",Age=21,ClassId=3 },
            new Student() {Name="小四",Id="20180310151",Age=26,ClassId=4 },
        };
            //1.	查询所有学生信息
            //var list = from s in Students select s;  //Linq方法

            //var list=Students .Select (s=>s);   //Lambda方法
            //foreach (var item in list)
            //{
            //    Console.WriteLine("Name={0},Id={1},Age={2},ClassId={3}", item.Name, item.Id, item.Age, item.ClassId);
            //}

            //2.	查询所有学生的学号和姓名
            //var list = from s in Students select new { s.Name, s.Id };  //Linq方法

            //var list = Students.Select(s => new { s.Name, s.Id });     //Lambda方法
            //foreach (var item in list)
            //{
            //    Console.WriteLine("Name={0},Id={1}", item.Name, item.Id);


            //3.	查询年龄小于25的学生的学号和姓名，并降序排列
            //var list = from s in Students where s.Age < 25 orderby s.Age descending select s;  //Linq方法

            //var list = Students .Where(s => s.Age < 25) .OrderByDescending(s => s.Age) .Select(s => s);   //Lambda方法
            //foreach (var item in list)
            //{
            //    Console.WriteLine("Name={0},Id={1}", item.Name, item.Id);
            //}

            //4.	查询姓名包含“小”，年龄小于25的学生信息
            //var list = from s in Students where s.Age < 25 && s.Name.Contains("小") select s;    //Linq方法

            //var list = Students.Where(s => s.Age < 25 && s.Name.Contains("小")) .Select(s=>s);    //Lambda方法
            //foreach (var item in list)
            //{
            //    Console.WriteLine("Name={0},Id={1},Age={2},ClassId={3}", item.Name, item.Id, item.Age, item.ClassId);
            //}

            //5.	查询“2”班的人数
            //var list = (from s in Students where s.ClassId==2  select s).Count();       //Linq方法

            //var list = Students.Where(s => s.ClassId == 2).Select(s => s).Count();      //Lambda方法
            //Console.WriteLine("2班的人数有:{0}", list);

            //6.	查询有哪些班级号
            //var list = (from s in Students select new {s.ClassId }).Distinct();        //Linq方法

            //var list = Students.Select(s => new { s.ClassId }).Distinct();             //Lambda方法
            //foreach (var item in list)
            //{
            //    Console.WriteLine("ClassId={0}", item.ClassId);
            //}

            //7.	查询每班人数
            //var list = from s in Students group s by s.ClassId into s1 select new { ClassId = s1.Key, sum = s1.Count() };    //Linq方法

            //var list = Students.GroupBy(s => s.ClassId).Select(s1 => new { ClassId = s1.Key, sum = s1.Count() });          //Lambda方法
            //foreach (var item in list)
            //{
            //    Console.WriteLine("ClassId={0},sum={1}", item.ClassId, item.sum);
            //}

            //8.	查询学生姓名和所在班级名称
            //var list = from s in Students join c in ClassList on s.ClassId equals c.Id select new { s.Name, c.ClassName };       //Linq方法
            var list = Students.Join(ClassList, s => s.ClassId, c => c.Id, (s, c) => new { s.Name, c.ClassName });         //Lambda方法

            foreach (var item in list)
            {
                Console.WriteLine("ClassId={0},Name={1}", item.ClassName, item.Name);
            }


            Console.ReadLine();
        }
    }
}
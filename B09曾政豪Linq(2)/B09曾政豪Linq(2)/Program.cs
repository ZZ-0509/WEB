using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B09曾政豪Linq_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<S> SList = new List<S>()
            {
                new S() {Son="20180310140",Sname="曾政豪",Sex="男",Dept="电子信息",Age=20 },
                new S() {Son="20180310141",Sname="韦子熊",Sex="男",Dept="土木工程",Age=19 },
                new S() {Son="4642144",Sname="林冲",Sex="男",Dept="传统武术",Age=30 },
                new S() {Son="1364548",Sname="林薇因",Sex="女",Dept="土木工程",Age=18 },
                new S() {Son="4987464",Sname="林子聪",Sex="男",Dept="美术艺术",Age=25 },
                new S() {Son="2316598",Sname="张三",Sex="女",Dept="贸易与旅游",Age=19 },
                new S() {Son="9874145",Sname="李四",Sex="女",Dept="食品安全",Age=21 },
                new S() {Son="1348644",Sname="武久",Sex="女",Dept="汽修工程",Age=18 },
                new S() {Son="3554645",Sname="樊豪",Sex="男",Dept="电子信息",Age=20 },
                new S() {Son="7845541",Sname="彭卫国",Sex="男",Dept="电子信息",Age=20 },
                new S() {Son="4642144",Sname="武林",Sex="男",Dept="传统武术",Age=19 }
            };
            List<SC> SCList = new List<SC>()
            {
                new SC() { Son="20180310140",Grade=100},
                new SC() { Son="20180310141",Grade=99},
                new SC() { Son="4642144",Grade=98},
                new SC() { Son="1364548",Grade=97},
                new SC() { Son="4987464",Grade=96},
                new SC() { Son="2316598",Grade=95},
                new SC() { Son="9874145",Grade=94},
                new SC() { Son="1348644",Grade=93},
                new SC() { Son="3554645",Grade=92},
                new SC() { Son="7845541",Grade=91},
            };

            //1.查询年龄小于20岁且姓名含有“林”的男生的学号，姓名，性别和系别
            var D = from v in SList where v.Age < 20 && v.Sname.Contains("林")&&v.Sex.Contains("男") select v;
            foreach (var V in D)
            {
                Console.WriteLine("学号:{0},姓名:{1},性别:{2},院系:{3}", V.Son, V.Sname, V.Sex, V.Dept);
            }

            Console.WriteLine();

            //2.统计各系的人数
            var C = from v in SList
                    group v by v.Dept into v
                    select new { Dept = v.Key, sum = v.Count() };
            foreach (var V in C)
            {
                Console.WriteLine("院系:{0},人数:{1}", V.Dept, V.sum);
            }

            Console.WriteLine();

            //3.查询有哪些系别
            var B = (from v in SList select new { v.Dept }).Distinct();
            foreach (var V in B)
            {
                Console.WriteLine("有{0}院系", V.Dept);
            }

            Console.WriteLine();

            //4.查询成绩大于80分的学生的姓名、系别、成绩，并按成绩降序排列
            var A = from v in SList join b in SCList on v.Son equals b.Son orderby b.Grade descending where b.Grade>80 select new {v.Sname,v.Dept,b.Grade  };
            foreach (var V in A)
            {
                Console.WriteLine("姓名:{0} ,院系:{1} ,成绩:{2}", V.Sname, V.Dept, V.Grade);
            }
                Console.ReadLine();
        }
    }
}

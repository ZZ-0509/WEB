using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFrist.Models
{
    public class Course
    {
        public int CourseId { get;set;}   //课程ID
        public string CourseName { get;set;}  //课程名
        public int Credit { get;set;}  //学分
        public int DepartmentId { get;set; }  //院系ID
        public virtual Department Department { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFrist.Models
{
    public class Department
    {
        public int DepartmentId { get;set; }   //院系ID
        public string Sdept { get; set; }   //院系名
        public string Dean { get;set; }   //院系主任
        public virtual ICollection<Course> Courses { set; get; }
    }
}

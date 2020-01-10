using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Many.Models
{
    public class Role
    { 
        public int Id { set; get; }
        public string Name { set; get; }   
        public string Dir { set; get; }   //描述
        public virtual ICollection<User> Users { set; get; }
    }
}
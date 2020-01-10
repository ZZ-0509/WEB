using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Many.Models
{
    public class User
    {
        public int Id { set; get; }
        public string Name { set; get; }      //账号
        public int Password { set; get; }    //密码
        public DateTime RegisterOn { set; get; }   //注册时间
        public virtual ICollection<Role> Roles { set; get; }
    }
}
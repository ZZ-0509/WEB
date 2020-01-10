using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZZY.Net.Library
{
    public class User
    {
        public int UserId
        {
            set; get;
        }
        public string Email             //电子邮件
        {
            set; get;
        }
        public string Password         //密码
        {
            set; get;
        }
        public string UserName          //用户名
        {
            set; get;
        }
        public DateTime Regtime           //注册时间
        {
            set; get;
        }
        public int RoleId
        {
            set; get;
        }

        public virtual Role Role { set; get; }
    }
}

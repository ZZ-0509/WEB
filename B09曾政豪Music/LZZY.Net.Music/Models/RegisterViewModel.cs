using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LZZY.Net.Music.Models
{
    public class RegisterViewModel
    {

        [Display(Name = "电子邮件:")]
        public string Email             //电子邮件
        {
            set; get;
        }
        [Display(Name = "用户名:")]
        public string UserName          //用户名
        {
            set; get;
        }
        [Display(Name = "密码:")]
        public string Password         //密码
        {
            set; get;
        }
        public int RoleId
        {
            set; get;
        }
     
    }
}
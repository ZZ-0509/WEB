using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LZZY.Net.Music.Models
{
    public class UserViewModel
    {
        public int UserId
        {
            set; get;
        }
        [Display(Name ="邮箱")]
        [Required(ErrorMessage = "邮箱不能为空")]
        public string Email             //电子邮件
        {
            set; get;
        }
        [Display(Name ="密码")]
        [Required(ErrorMessage ="密码不能为空")]
        [StringLength(128,MinimumLength =5,ErrorMessage ="密码不能低于5位数")]
        public string Password         //密码
        {
            set; get;
        }
    }
}
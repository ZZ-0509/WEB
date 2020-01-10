using LZZY.Net.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LZZY.Net.Music.Models
{
    public class ManagViewModel
    {
        public int GenreId
        {
            set; get;
        }
        public int SingerId
        {
            set; get;
        }
        public int UserId
        {
            set; get;
        }
        public int RoleId
        {
            set; get;
        }
        [Display(Name = "流派名称：")]
        public string GenreName   //流派名称
        {
            set; get;
        }
        [Display(Name = "流派描述：")]
        public string Describe     //流派描述
        {
            set; get;
        }
        [Display(Name = "歌手：")]
        public string SingerName           //歌手姓名
        {
            set; get;
        }
        [Display(Name = "性别：")]
        public string Gender        //性别
        {
            set; get;
        }
        [Display(Name = "歌手介绍：")]
        public string Introduce        //歌手介绍
        {
            set; get;
        }
        [Display(Name = "电子邮件：")]
        public string Email             //电子邮件
        {
            set; get;
        }
        [Display(Name = "密码：")]
        public string Password         //密码
        {
            set; get;
        }
        [Display(Name = "用户名：")]
        public string UserName          //用户名
        {
            set; get;
        }
        [Display(Name = "注册时间：")]
        public DateTime Regtime           //注册时间
        {
            set; get;
        }
        public virtual Role Role { set; get; }
    }
}

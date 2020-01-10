using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class Movie
    {
        public int MovieId { set; get; }        //电影ID
        [Display(Name = "电影名：")]
        public string MovieName { set; get; }   //电影名
        [Display(Name ="上映时间:")]
        public DateTime Time { set; get; }        //上映时间
        [Display(Name = "地区：")]
        public string Region { set; get; }      //地区
        [Display(Name = "类型：")]
        public int MovieTypeId { set; get; }         //类型ID
        public virtual MovieType movieType { set; get; }
    }
}
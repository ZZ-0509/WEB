using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMovie.Models
{
    public class Movie    //电影表
    {
        public int MovieId { set; get; }        //电影ID

        [Required(ErrorMessage = "电影名是必填项")]
        public string MovieName { set; get; }   //电影名
        public string Director { set; get; }     //导演
        public int MovieLength { set; get; }     //片长
        public DateTime Time { set; get; }        //上映时间
        public string Region { set; get; }      //地区
        public decimal Price { set; get; }          //价格
        public int MovieTypeId { set; get; }         //类型ID
        public virtual MovieType MovieType { set; get; }
        public virtual ICollection<Prize> Prizes { set; get; }
    }
}
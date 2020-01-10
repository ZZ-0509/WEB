using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LZZY.Net.Music.Models
{
    public class AlbumListViewModel
    {
        public int AlbumId
        {
            set; get;
        }
        [Display(Name = "专辑名称")]
        public string AlbumName     //专辑名称
        {
            set; get;
        }
        [Display(Name = "价格")]
        public int  Price        //价格
        {
            set; get;
        }
        [Display(Name = "上架时间")]
        public DateTime ShelfTime     //上架时间
        {
            set; get;
        }
        [Display(Name = "专辑封面")]
        public string Website             //专辑网址
        {
            set; get;
        }
        public int GenreId
        {
            set; get;
        }
        public string GenreName   //流派名称
        {
            set; get;
        }
        public int SingerId
        {
            set; get;
        }
        public string SingerName           //歌手
        {
            set; get;
        }
        public SelectList Singers
        {
            set; get;
        }
        public SelectList Genres
        {
            set; get;
        }
    }
}
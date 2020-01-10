using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LZZY.Net.Music.Models
{
    public class AlbumViewModel
    {
        public int AlbumId
        {
            set; get;
        }
        public string AlbumName     //专辑名称
        {
            set; get;
        }
        public int Price        //价格
        {
            set; get;
        }
        public DateTime ShelfTime     //上架时间
        {
            set; get;
        }
        public string Website             //专辑网址
        {
            set; get;
        }
        public string SingerName           //姓名
        {
            set; get;
        }
        public string GenreName   //名称
        {
            set; get;
        }
    }
}
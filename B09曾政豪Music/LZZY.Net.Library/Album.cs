using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZZY.Net.Library
{
    public class Album    //专辑
    {
        public int AlbumId      
        {
            set;get;
        }
        public string AlbumName     //专辑名称
        {
            set; get;
        }
        public int   Price        //价格
        {
            set; get;
        }
        public DateTime ShelfTime     //上架时间
        {
            set; get;
        }
        public int GenreId
        {
            set; get;
        }
        public int SingerId
        {
            set; get;
        }
        public string Website             //专辑网址
        {
            set; get;
        }


        public virtual Genre Genre { set; get; }
        public virtual Singer Singer { set; get; }
    }
}

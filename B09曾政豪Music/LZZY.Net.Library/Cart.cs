using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZZY.Net.Library
{
    public class Cart
    {
        public int CartId
        {
            get;set;
        }
        public string UserName         //用户名
        {
            get; set;
        }
        public int Quantity            //数量
        {
            get; set;
        }
        public DateTime Date          //时间
        {
            get; set;
        }
        public int AlbumId
        {
            get; set;
        }
        public virtual Album Album { set; get; }
    }
}

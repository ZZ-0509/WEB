using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZZY.Net.Library
{
    public class CsorderDetail
    {
        public int CsorderDetailID
        {
            set; get; 
}
        public int Quantity     //数量
        {
            get; set;
        }

        public int Price        //价格
        {
            set; get;
        }
        public int AlbumId
        {
            set; get;
        }
        public int OrderID { get; set; }
        public virtual Genre Genre { set; get; }
        public virtual Album Album { set; get; }
    }
}

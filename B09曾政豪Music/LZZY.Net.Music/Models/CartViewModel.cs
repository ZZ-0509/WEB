using LZZY.Net.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LZZY.Net.Music.Models
{
    public class CartViewModel
    {
        public List<Cart> CartItems { set; get; }
        public decimal CartTotal { set; get; }
    }
}
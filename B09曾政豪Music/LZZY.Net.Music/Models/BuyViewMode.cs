﻿using LZZY.Net.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LZZY.Net.Music.Models
{
    public class BuyViewMode
    {
        public string OrderName { get; set; }     //用户名
        public string Addressee { get; set; }       //收件人
        public string Country { get; set; }     //国家
        public string Province { get; set; }      //省
        public string City { get; set; }        //市
        public string Address { get; set; }     //地址
        public int ZipCode { get; set; }         //邮编
        public int Phone { get; set; }           //电话
        public decimal Total { get; set; }        //总价
        public DateTime OrderTime { get; set; }     //订单时间
        public List<CsorderDetail> CsorderDetails { set; get; }
    }
}
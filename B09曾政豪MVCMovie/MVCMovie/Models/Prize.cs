using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMovie.Models
{
    public class Prize
    {
        public int Id { set; get; }
        public string Name { set; get; }      //奖项名称
        public string Period { set; get; }    //颁奖时间
        public DateTime StarTime { set; get; }     //创办时间
        public string Sponsor { set; get; }      //主办单位
        public virtual ICollection<Movie> Movies { set; get; }
    }
}
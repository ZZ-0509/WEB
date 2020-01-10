using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMovie.Models
{
    public class MovieType    //类型表
    {
        public int MovieTypeId { set; get; }  //类型ID
        public string TypeName { set; get; }  //电影类型
        public virtual ICollection<Movie> Movies { set; get; }
    }
}
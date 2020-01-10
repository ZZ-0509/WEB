using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZZY.Net.Library
{
    public class Genre    //流派
    {
        public int GenreId
        {
            set; get;
        }
        [Display(Name = "流派名称：")]
        public string GenreName   //名称
        {
            set; get;
        }
        [Display(Name = "流派描述：")]
        public string Describe     //描述
        {
            set; get;
        }
        public virtual ICollection<Album> Albums { set; get; }
    }
}

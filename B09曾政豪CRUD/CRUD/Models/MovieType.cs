using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class MovieType
    {
        public int MovieTypeId { set; get; }  //类型ID

        [Display(Name ="类型：")]
        [Required]
        public string TypeName { set; get; }  //电影类型
        public virtual ICollection<Movie> Movies { set; get; }
    }
}
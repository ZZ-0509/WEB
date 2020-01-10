using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Models
{
    public class BlogUser
    {
        public int BlogUserID { set; get; }
        public string BlogName{ set; get; }
        public virtual ICollection<Post> Posts { set; get; }
}
}

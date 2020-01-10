using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Models
{
    public class Post
    {
        public int PostID { set; get; }
        public string PostTitle { set; get; }
        public string PostContent { set; get; }
        public int BlogUserID { set; get; }
        public virtual BlogUser BlogUset { set; get; }

    }
}

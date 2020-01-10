using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZZY.Net.Library
{
    public class Role
    {
        public int RoleId
        {
            set; get;
        }
        public string RoleName        //角色名称
        {
            set; get;
        }
        public string Resume         //权限
        {
            set; get;
        }
        public virtual ICollection<User> Users { set; get; }
    }
}

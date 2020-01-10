using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LZZY.Net.Music.Filters
{
    public class RoleFilter : ActionFilterAttribute
    {
        private readonly string _value;
        public RoleFilter (string role)
        {
            _value = role;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["userrole"] != null)
            {
                if (filterContext.HttpContext.Session["userrole"].ToString() != _value)
                {
                    filterContext.Result = new ContentResult()
                    {
                        Content = "对不起，您无权访问。"
                    };
                }
            }
            else
            {
                filterContext.Result = new ContentResult()
                {
                    Content = "对不起，您无权访问。"
                };
            }
        }
    }
}
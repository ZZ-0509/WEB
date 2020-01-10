using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.HTML
{
    public static class Helpers
    {
        public static MvcHtmlString Image(this HtmlHelper helper,string src,string alt)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            TagBuilder builder = new TagBuilder("img");
            builder.MergeAttribute("src", urlHelper.Content(src));
            builder.MergeAttribute("alt", alt);
            builder.ToString(TagRenderMode.SelfClosing);
            return MvcHtmlString.Create(builder.ToString());
        }

        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            if (input.Length < length)
            {
                return input;
            }
            else
            {
                var newInput = input.Substring(0, length) + "...";
                return newInput;
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Marquite.Core.Html
{
    public static class PartialExtensions
    {
        public static MvcHtmlString Partial(this HtmlHelper htmlHelper, string partialViewName)
        {
            return System.Web.Mvc.Html.PartialExtensions.Partial(htmlHelper, partialViewName);
        }

        public static MvcHtmlString Partial(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData)
        {
            return System.Web.Mvc.Html.PartialExtensions.Partial(htmlHelper, partialViewName,viewData);
        }

        public static MvcHtmlString Partial(this HtmlHelper htmlHelper, string partialViewName, object model)
        {
            return System.Web.Mvc.Html.PartialExtensions.Partial(htmlHelper, partialViewName,model);
        }

        public static MvcHtmlString Partial(this HtmlHelper htmlHelper, string partialViewName, object model, ViewDataDictionary viewData)
        {
            return System.Web.Mvc.Html.PartialExtensions.Partial(htmlHelper, partialViewName,model,viewData);
        }
    }
}

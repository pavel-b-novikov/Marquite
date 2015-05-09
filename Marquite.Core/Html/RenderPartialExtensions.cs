using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Marquite.Core.Html
{
    public static class RenderPartialExtensions
    {
        // Renders the partial view with the parent's view data and model
        public static void RenderPartial(this HtmlHelper htmlHelper, string partialViewName)
        {
            System.Web.Mvc.Html.RenderPartialExtensions.RenderPartial(htmlHelper,partialViewName);
        }

        // Renders the partial view with the given view data and, implicitly, the given view data's model
        public static void RenderPartial(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData)
        {
            System.Web.Mvc.Html.RenderPartialExtensions.RenderPartial(htmlHelper,partialViewName, viewData);
        }

        // Renders the partial view with an empty view data and the given model
        public static void RenderPartial(this HtmlHelper htmlHelper, string partialViewName, object model)
        {
            System.Web.Mvc.Html.RenderPartialExtensions.RenderPartial(htmlHelper,partialViewName, model);
        }

        // Renders the partial view with a copy of the given view data plus the given model
        public static void RenderPartial(this HtmlHelper htmlHelper, string partialViewName, object model, ViewDataDictionary viewData)
        {
            System.Web.Mvc.Html.RenderPartialExtensions.RenderPartial(htmlHelper,partialViewName, model,viewData);
        }
    }
}

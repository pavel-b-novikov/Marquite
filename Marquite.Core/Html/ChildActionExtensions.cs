using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Marquite.Core.MvcHelpers;

namespace Marquite.Core.Html
{
    public static class ChildActionExtensions
    {
        public static MvcHtmlString Action(this HtmlHelper htmlHelper, string actionName)
        {
            return System.Web.Mvc.Html.ChildActionExtensions.Action(htmlHelper, actionName);
        }

        public static MvcHtmlString Action(this HtmlHelper htmlHelper, string actionName, object routeValues)
        {
            return System.Web.Mvc.Html.ChildActionExtensions.Action(htmlHelper, actionName, routeValues);
        }

        public static MvcHtmlString Action(this HtmlHelper htmlHelper, string actionName, RouteValueDictionary routeValues)
        {
            return System.Web.Mvc.Html.ChildActionExtensions.Action(htmlHelper, actionName, routeValues);
        }

        public static MvcHtmlString Action(this HtmlHelper htmlHelper, string actionName, string controllerName)
        {
            return System.Web.Mvc.Html.ChildActionExtensions.Action(htmlHelper, actionName, controllerName);
        }

        public static MvcHtmlString Action(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues)
        {
            return System.Web.Mvc.Html.ChildActionExtensions.Action(htmlHelper, actionName, controllerName, routeValues);
        }

        public static MvcHtmlString Action(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            return System.Web.Mvc.Html.ChildActionExtensions.Action(htmlHelper, actionName, controllerName, routeValues);
        }

        public static void RenderAction(this HtmlHelper htmlHelper, string actionName)
        {
            System.Web.Mvc.Html.ChildActionExtensions.RenderAction(htmlHelper, actionName);
        }

        public static void RenderAction(this HtmlHelper htmlHelper, string actionName, object routeValues)
        {
            System.Web.Mvc.Html.ChildActionExtensions.RenderAction(htmlHelper, actionName, routeValues);
        }

        public static void RenderAction(this HtmlHelper htmlHelper, string actionName, RouteValueDictionary routeValues)
        {
            System.Web.Mvc.Html.ChildActionExtensions.RenderAction(htmlHelper, actionName, routeValues);
        }

        public static void RenderAction(this HtmlHelper htmlHelper, string actionName, string controllerName)
        {
            System.Web.Mvc.Html.ChildActionExtensions.RenderAction(htmlHelper, actionName, controllerName);
        }

        public static void RenderAction(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues)
        {
            System.Web.Mvc.Html.ChildActionExtensions.RenderAction(htmlHelper, actionName, controllerName, routeValues);
        }

        public static void RenderAction(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            System.Web.Mvc.Html.ChildActionExtensions.RenderAction(htmlHelper, actionName, controllerName, routeValues);
        }
    }
}

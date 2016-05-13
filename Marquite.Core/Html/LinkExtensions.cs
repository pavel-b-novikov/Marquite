using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Marquite.Core.Elements;
using Marquite.Core.MvcHelpers;

namespace Marquite.Core.Html
{
    public static class LinkExtensions
    {
        public static LinkBuilder ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName)
        {
            return ActionLink(htmlHelper, linkText, actionName, null /* controllerName */, new RouteValueDictionary(),
                new RouteValueDictionary());
        }

        public static LinkBuilder ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
            object routeValues)
        {
            return ActionLink(htmlHelper, linkText, actionName, null /* controllerName */,
                TypeHelper.ObjectToDictionary(routeValues), new RouteValueDictionary());
        }

        public static LinkBuilder ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
            object routeValues, object htmlAttributes)
        {
            return ActionLink(htmlHelper, linkText, actionName, null /* controllerName */,
                TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static LinkBuilder ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
            RouteValueDictionary routeValues)
        {
            return ActionLink(htmlHelper, linkText, actionName, null /* controllerName */, routeValues,
                new RouteValueDictionary());
        }

        public static LinkBuilder ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
            RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return ActionLink(htmlHelper, linkText, actionName, null /* controllerName */, routeValues, htmlAttributes);
        }

        public static LinkBuilder ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName)
        {
            return ActionLink(htmlHelper, linkText, actionName, controllerName, new RouteValueDictionary(),
                new RouteValueDictionary());
        }

        public static LinkBuilder ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName, object routeValues, object htmlAttributes)
        {
            return ActionLink(htmlHelper, linkText, actionName, controllerName,
                TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static LinkBuilder ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            if (string.IsNullOrEmpty(linkText))
            {
                throw new ArgumentException("linkText");
            }
            return GenerateLink(htmlHelper, htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText,
                null /* routeName */, actionName, controllerName, routeValues, htmlAttributes);
        }

        public static LinkBuilder ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName, string protocol, string hostName, string fragment, object routeValues,
            object htmlAttributes)
        {
            return ActionLink(htmlHelper, linkText, actionName, controllerName, protocol, hostName, fragment,
                TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static LinkBuilder ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues,
            IDictionary<string, object> htmlAttributes)
        {
            if (string.IsNullOrEmpty(linkText))
            {
                throw new ArgumentException("linkText");
            }
            return GenerateLink(htmlHelper, htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText,
                null /* routeName */, actionName, controllerName, protocol, hostName, fragment, routeValues,
                htmlAttributes);
        }

        public static LinkBuilder RouteLink(this HtmlHelper htmlHelper, string linkText, object routeValues)
        {
            return RouteLink(htmlHelper, linkText, TypeHelper.ObjectToDictionary(routeValues));
        }

        public static LinkBuilder RouteLink(this HtmlHelper htmlHelper, string linkText,
            RouteValueDictionary routeValues)
        {
            return RouteLink(htmlHelper, linkText, routeValues, new RouteValueDictionary());
        }

        public static LinkBuilder RouteLink(this HtmlHelper htmlHelper, string linkText, string routeName)
        {
            return RouteLink(htmlHelper, linkText, routeName, (object) null /* routeValues */);
        }

        public static LinkBuilder RouteLink(this HtmlHelper htmlHelper, string linkText, string routeName,
            object routeValues)
        {
            return RouteLink(htmlHelper, linkText, routeName, TypeHelper.ObjectToDictionary(routeValues));
        }

        public static LinkBuilder RouteLink(this HtmlHelper htmlHelper, string linkText, string routeName,
            RouteValueDictionary routeValues)
        {
            return RouteLink(htmlHelper, linkText, routeName, routeValues, new RouteValueDictionary());
        }

        public static LinkBuilder RouteLink(this HtmlHelper htmlHelper, string linkText, object routeValues,
            object htmlAttributes)
        {
            return RouteLink(htmlHelper, linkText, TypeHelper.ObjectToDictionary(routeValues),
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static LinkBuilder RouteLink(this HtmlHelper htmlHelper, string linkText,
            RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return RouteLink(htmlHelper, linkText, null /* routeName */, routeValues, htmlAttributes);
        }

        public static LinkBuilder RouteLink(this HtmlHelper htmlHelper, string linkText, string routeName,
            object routeValues, object htmlAttributes)
        {
            return RouteLink(htmlHelper, linkText, routeName, TypeHelper.ObjectToDictionary(routeValues),
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static LinkBuilder RouteLink(this HtmlHelper htmlHelper, string linkText, string routeName,
            RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            if (string.IsNullOrEmpty(linkText))
            {
                throw new ArgumentException("linkText");
            }
            return GenerateRouteLink(htmlHelper, htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection,
                linkText, routeName, routeValues, htmlAttributes);
        }

        public static LinkBuilder RouteLink(this HtmlHelper htmlHelper, string linkText, string routeName,
            string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
        {
            return RouteLink(htmlHelper, linkText, routeName, protocol, hostName, fragment,
                TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static LinkBuilder RouteLink(this HtmlHelper htmlHelper, string linkText, string routeName,
            string protocol, string hostName, string fragment, RouteValueDictionary routeValues,
            IDictionary<string, object> htmlAttributes)
        {
            if (string.IsNullOrEmpty(linkText))
            {
                throw new ArgumentException("linkText");
            }
            return GenerateRouteLink(htmlHelper, htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection,
                linkText, routeName, protocol, hostName, fragment, routeValues, htmlAttributes);
        }

        private static LinkBuilder GenerateLink(HtmlHelper htmlHelper, RequestContext requestContext,
            RouteCollection routeCollection, string linkText, string routeName, string actionName, string controllerName,
            string protocol, string hostName, string fragment, RouteValueDictionary routeValues,
            IDictionary<string, object> htmlAttributes, bool includeImplicitMvcValues)
        {
            var url = UrlHelper.GenerateUrl(routeName, actionName, controllerName, protocol, hostName, fragment,
                routeValues, routeCollection, requestContext, includeImplicitMvcValues);
            var lb = new LinkBuilder(htmlHelper.Marq());
            lb.MergeAttributes(htmlAttributes);
            lb.Href(url).Content(c => c.AppendText(linkText));
            return lb;
        }

        public static LinkBuilder GenerateRouteLink(HtmlHelper htmlHelper, RequestContext requestContext,
            RouteCollection routeCollection, string linkText, string routeName, string protocol, string hostName,
            string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return GenerateLink(htmlHelper, requestContext, routeCollection, linkText, routeName, null /* actionName */,
                null /* controllerName */, protocol, hostName, fragment, routeValues, htmlAttributes, false
                /* includeImplicitMvcValues */);
        }

        public static LinkBuilder GenerateRouteLink(HtmlHelper htmlHelper, RequestContext requestContext,
            RouteCollection routeCollection, string linkText, string routeName, RouteValueDictionary routeValues,
            IDictionary<string, object> htmlAttributes)
        {
            return GenerateRouteLink(htmlHelper, requestContext, routeCollection, linkText, routeName, null
                /* protocol */, null /* hostName */, null /* fragment */, routeValues, htmlAttributes);
        }

        public static LinkBuilder GenerateLink(HtmlHelper htmlHelper, RequestContext requestContext,
            RouteCollection routeCollection, string linkText, string routeName, string actionName, string controllerName,
            string protocol, string hostName, string fragment, RouteValueDictionary routeValues,
            IDictionary<string, object> htmlAttributes)
        {
            return GenerateLink(htmlHelper, requestContext, routeCollection, linkText, routeName, actionName,
                controllerName, protocol, hostName, fragment, routeValues, htmlAttributes, true
                /* includeImplicitMvcValues */);
        }

        public static LinkBuilder GenerateLink(HtmlHelper htmlHelper, RequestContext requestContext,
            RouteCollection routeCollection, string linkText, string routeName, string actionName, string controllerName,
            RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return GenerateLink(htmlHelper, requestContext, routeCollection, linkText, routeName, actionName,
                controllerName, null /* protocol */, null /* hostName */, null /* fragment */, routeValues,
                htmlAttributes);
        }
    }
}
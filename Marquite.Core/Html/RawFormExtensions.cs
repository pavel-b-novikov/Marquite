using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Marquite.Core.ElementBuilders;
using Marquite.Core.MvcHelpers;

namespace Marquite.Core.Html
{
    public static class RawFormExtensions
    {
        public static FormBuilder Form(this HtmlHelper htmlHelper, object routeValues)
        {
            return Form(htmlHelper, null, null, TypeHelper.ObjectToDictionary(routeValues), FormMethod.Post, new RouteValueDictionary());
        }

        public static FormBuilder Form(this HtmlHelper htmlHelper, RouteValueDictionary routeValues)
        {
            return Form(htmlHelper, null, null, routeValues, FormMethod.Post, new RouteValueDictionary());
        }

        public static FormBuilder Form(this HtmlHelper htmlHelper, string actionName, string controllerName)
        {
            return Form(htmlHelper, actionName, controllerName, new RouteValueDictionary(), FormMethod.Post, new RouteValueDictionary());
        }

        public static FormBuilder Form(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues)
        {
            return Form(htmlHelper, actionName, controllerName, TypeHelper.ObjectToDictionary(routeValues), FormMethod.Post, new RouteValueDictionary());
        }

        public static FormBuilder Form(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            return Form(htmlHelper, actionName, controllerName, routeValues, FormMethod.Post, new RouteValueDictionary());
        }

        public static FormBuilder Form(this HtmlHelper htmlHelper, string actionName, string controllerName, FormMethod method)
        {
            return Form(htmlHelper, actionName, controllerName, new RouteValueDictionary(), method, new RouteValueDictionary());
        }

        public static FormBuilder Form(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, FormMethod method)
        {
            return Form(htmlHelper, actionName, controllerName, TypeHelper.ObjectToDictionary(routeValues), method, new RouteValueDictionary());
        }

        public static FormBuilder Form(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, FormMethod method)
        {
            return Form(htmlHelper, actionName, controllerName, routeValues, method, new RouteValueDictionary());
        }

        public static FormBuilder Form(this HtmlHelper htmlHelper, string actionName, string controllerName, FormMethod method, object htmlAttributes)
        {
            return Form(htmlHelper, actionName, controllerName, new RouteValueDictionary(), method, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static FormBuilder Form(this HtmlHelper htmlHelper, string actionName, string controllerName, FormMethod method, IDictionary<string, object> htmlAttributes)
        {
            return Form(htmlHelper, actionName, controllerName, new RouteValueDictionary(), method, htmlAttributes);
        }

        public static FormBuilder Form(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, FormMethod method, object htmlAttributes)
        {
            return Form(htmlHelper, actionName, controllerName, TypeHelper.ObjectToDictionary(routeValues), method, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static FormBuilder Form(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, FormMethod method, IDictionary<string, object> htmlAttributes)
        {
            return FormExtensions.CreateForm(htmlHelper, actionName, controllerName, routeValues, method, htmlAttributes);
        }

        public static FormBuilder RouteForm(this HtmlHelper htmlHelper, object routeValues)
        {
            return RouteForm(htmlHelper, null /* routeName */, TypeHelper.ObjectToDictionary(routeValues), FormMethod.Post, new RouteValueDictionary());
        }

        public static FormBuilder RouteForm(this HtmlHelper htmlHelper, RouteValueDictionary routeValues)
        {
            return RouteForm(htmlHelper, null /* routeName */, routeValues, FormMethod.Post, new RouteValueDictionary());
        }

        public static FormBuilder RouteForm(this HtmlHelper htmlHelper, string routeName)
        {
            return RouteForm(htmlHelper, routeName, new RouteValueDictionary(), FormMethod.Post, new RouteValueDictionary());
        }

        public static FormBuilder RouteForm(this HtmlHelper htmlHelper, string routeName, object routeValues)
        {
            return RouteForm(htmlHelper, routeName, TypeHelper.ObjectToDictionary(routeValues), FormMethod.Post, new RouteValueDictionary());
        }

        public static FormBuilder RouteForm(this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues)
        {
            return RouteForm(htmlHelper, routeName, routeValues, FormMethod.Post, new RouteValueDictionary());
        }

        public static FormBuilder RouteForm(this HtmlHelper htmlHelper, string routeName, FormMethod method)
        {
            return RouteForm(htmlHelper, routeName, new RouteValueDictionary(), method, new RouteValueDictionary());
        }

        public static FormBuilder RouteForm(this HtmlHelper htmlHelper, string routeName, object routeValues, FormMethod method)
        {
            return RouteForm(htmlHelper, routeName, TypeHelper.ObjectToDictionary(routeValues), method, new RouteValueDictionary());
        }

        public static FormBuilder RouteForm(this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues, FormMethod method)
        {
            return RouteForm(htmlHelper, routeName, routeValues, method, new RouteValueDictionary());
        }

        public static FormBuilder RouteForm(this HtmlHelper htmlHelper, string routeName, FormMethod method, object htmlAttributes)
        {
            return RouteForm(htmlHelper, routeName, new RouteValueDictionary(), method, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static FormBuilder RouteForm(this HtmlHelper htmlHelper, string routeName, FormMethod method, IDictionary<string, object> htmlAttributes)
        {
            return RouteForm(htmlHelper, routeName, new RouteValueDictionary(), method, htmlAttributes);
        }

        public static FormBuilder RouteForm(this HtmlHelper htmlHelper, string routeName, object routeValues, FormMethod method, object htmlAttributes)
        {
            return RouteForm(htmlHelper, routeName, TypeHelper.ObjectToDictionary(routeValues), method, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static FormBuilder RouteForm(this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues, FormMethod method, IDictionary<string, object> htmlAttributes)
        {
            return FormExtensions.CreateRouteForm(htmlHelper, routeName, routeValues, method, htmlAttributes);
        }
    }
}

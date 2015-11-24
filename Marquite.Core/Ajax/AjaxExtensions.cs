using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Marquite.Core.Elements;
using Marquite.Core.Html;
using Marquite.Core.MvcHelpers;

namespace Marquite.Core.Ajax
{
    public static class AjaxExtensions
    {
        private const string LinkOnClickFormat = "Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {0});";
        private const string FormOnClickValue = "Sys.Mvc.AsyncForm.handleClick(this, new Sys.UI.DomEvent(event));";
        private const string FormOnSubmitFormat = "Sys.Mvc.AsyncForm.handleSubmit(this, new Sys.UI.DomEvent(event), {0});";

        #region ActionLink
        public static LinkBuilder ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, AjaxOptions ajaxOptions)
        {
            return ActionLink(ajaxHelper, linkText, actionName, (string)null /* controllerName */, ajaxOptions);
        }

        public static LinkBuilder ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, object routeValues, AjaxOptions ajaxOptions)
        {
            return ActionLink(ajaxHelper, linkText, actionName, (string)null /* controllerName */, routeValues, ajaxOptions);
        }

        public static LinkBuilder ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return ActionLink(ajaxHelper, linkText, actionName, (string)null /* controllerName */, routeValues, ajaxOptions, htmlAttributes);
        }

        public static LinkBuilder ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return ActionLink(ajaxHelper, linkText, actionName, (string)null /* controllerName */, routeValues, ajaxOptions);
        }

        public static LinkBuilder ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return ActionLink(ajaxHelper, linkText, actionName, (string)null /* controllerName */, routeValues, ajaxOptions, htmlAttributes);
        }

        public static LinkBuilder ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            return ActionLink(ajaxHelper, linkText, actionName, controllerName, null /* values */, ajaxOptions, null /* htmlAttributes */);
        }

        public static LinkBuilder ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions)
        {
            return ActionLink(ajaxHelper, linkText, actionName, controllerName, routeValues, ajaxOptions, null /* htmlAttributes */);
        }

        public static LinkBuilder ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            RouteValueDictionary newValues = TypeHelper.ObjectToDictionary(routeValues);
            RouteValueDictionary newAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return ActionLink(ajaxHelper, linkText, actionName, controllerName, newValues, ajaxOptions, newAttributes);
        }

        public static LinkBuilder ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return ActionLink(ajaxHelper, linkText, actionName, controllerName, routeValues, ajaxOptions, null /* htmlAttributes */);
        }

        public static LinkBuilder ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(linkText))
            {
                throw new ArgumentException("Value cannot be null or empty.", "linkText");
            }

            string targetUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, true /* includeImplicitMvcValues */);

            return GenerateLink(ajaxHelper, linkText, targetUrl, GetAjaxOptions(ajaxOptions), htmlAttributes);
        }

        public static LinkBuilder ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            RouteValueDictionary newValues = TypeHelper.ObjectToDictionary(routeValues);
            RouteValueDictionary newAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return ActionLink(ajaxHelper, linkText, actionName, controllerName, protocol, hostName, fragment, newValues, ajaxOptions, newAttributes);
        }

        public static LinkBuilder ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(linkText))
            {
                throw new ArgumentException("Value cannot be null or empty.", "linkText");
            }

            string targetUrl = UrlHelper.GenerateUrl(null /* routeName */, actionName, controllerName, protocol, hostName, fragment, routeValues, ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, true /* includeImplicitMvcValues */);

            return GenerateLink(ajaxHelper, linkText, targetUrl, ajaxOptions, htmlAttributes);
        }
#endregion

        #region BeginForm
        public static ITagScope BeginForm(this AjaxHelper ajaxHelper, AjaxOptions ajaxOptions)
        {
            string formAction = ajaxHelper.ViewContext.HttpContext.Request.RawUrl;
            return FormHelper(ajaxHelper, formAction, ajaxOptions, new RouteValueDictionary()).Open();
        }

        public static ITagScope BeginForm(this AjaxHelper ajaxHelper, string actionName, AjaxOptions ajaxOptions)
        {
            return BeginForm(ajaxHelper, actionName, (string)null /* controllerName */, ajaxOptions);
        }

        public static ITagScope BeginForm(this AjaxHelper ajaxHelper, string actionName, object routeValues, AjaxOptions ajaxOptions)
        {
            return BeginForm(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions);
        }

        public static ITagScope BeginForm(this AjaxHelper ajaxHelper, string actionName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return BeginForm(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions, htmlAttributes);
        }

        public static ITagScope BeginForm(this AjaxHelper ajaxHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return BeginForm(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions);
        }

        public static ITagScope BeginForm(this AjaxHelper ajaxHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return BeginForm(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions, htmlAttributes);
        }

        public static ITagScope BeginForm(this AjaxHelper ajaxHelper, string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            return BeginForm(ajaxHelper, actionName, controllerName, null /* values */, ajaxOptions, null /* htmlAttributes */);
        }

        public static ITagScope BeginForm(this AjaxHelper ajaxHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions)
        {
            return BeginForm(ajaxHelper, actionName, controllerName, routeValues, ajaxOptions, null /* htmlAttributes */);
        }

        public static ITagScope BeginForm(this AjaxHelper ajaxHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            RouteValueDictionary newValues = new RouteValueDictionary(routeValues);
            RouteValueDictionary newAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return BeginForm(ajaxHelper, actionName, controllerName, newValues, ajaxOptions, newAttributes);
        }

        public static ITagScope BeginForm(this AjaxHelper ajaxHelper, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return BeginForm(ajaxHelper, actionName, controllerName, routeValues, ajaxOptions, null /* htmlAttributes */);
        }

        public static ITagScope BeginForm(this AjaxHelper ajaxHelper, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            // get target URL
            string formAction = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues ?? new RouteValueDictionary(), ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, true /* includeImplicitMvcValues */);
            return FormHelper(ajaxHelper, formAction, ajaxOptions, htmlAttributes).Open();
        }

        public static ITagScope BeginRouteForm(this AjaxHelper ajaxHelper, string routeName, AjaxOptions ajaxOptions)
        {
            return BeginRouteForm(ajaxHelper, routeName, null /* routeValues */, ajaxOptions, null /* htmlAttributes */);
        }

        public static ITagScope BeginRouteForm(this AjaxHelper ajaxHelper, string routeName, object routeValues, AjaxOptions ajaxOptions)
        {
            return BeginRouteForm(ajaxHelper, routeName, (object)routeValues, ajaxOptions, null /* htmlAttributes */);
        }

        public static ITagScope BeginRouteForm(this AjaxHelper ajaxHelper, string routeName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            RouteValueDictionary newAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return BeginRouteForm(ajaxHelper, routeName, new RouteValueDictionary(routeValues), ajaxOptions, newAttributes);
        }

        public static ITagScope BeginRouteForm(this AjaxHelper ajaxHelper, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return BeginRouteForm(ajaxHelper, routeName, routeValues, ajaxOptions, null /* htmlAttributes */);
        }

        public static ITagScope BeginRouteForm(this AjaxHelper ajaxHelper, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            string formAction = UrlHelper.GenerateUrl(routeName, null /* actionName */, null /* controllerName */, routeValues ?? new RouteValueDictionary(), ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, false /* includeImplicitMvcValues */);
            return FormHelper(ajaxHelper, formAction, ajaxOptions, htmlAttributes).Open();
        }
        #endregion

        #region Form
        public static FormBuilder Form(this AjaxHelper ajaxHelper, AjaxOptions ajaxOptions)
        {
            string formAction = ajaxHelper.ViewContext.HttpContext.Request.RawUrl;
            return FormHelper(ajaxHelper, formAction, ajaxOptions, new RouteValueDictionary());
        }

        public static FormBuilder Form(this AjaxHelper ajaxHelper, string actionName, AjaxOptions ajaxOptions)
        {
            return Form(ajaxHelper, actionName, (string)null /* controllerName */, ajaxOptions);
        }

        public static FormBuilder Form(this AjaxHelper ajaxHelper, string actionName, object routeValues, AjaxOptions ajaxOptions)
        {
            return Form(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions);
        }

        public static FormBuilder Form(this AjaxHelper ajaxHelper, string actionName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return Form(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions, htmlAttributes);
        }

        public static FormBuilder Form(this AjaxHelper ajaxHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return Form(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions);
        }

        public static FormBuilder Form(this AjaxHelper ajaxHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return Form(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions, htmlAttributes);
        }

        public static FormBuilder Form(this AjaxHelper ajaxHelper, string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            return Form(ajaxHelper, actionName, controllerName, null /* values */, ajaxOptions, null /* htmlAttributes */);
        }

        public static FormBuilder Form(this AjaxHelper ajaxHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions)
        {
            return Form(ajaxHelper, actionName, controllerName, routeValues, ajaxOptions, null /* htmlAttributes */);
        }

        public static FormBuilder Form(this AjaxHelper ajaxHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            RouteValueDictionary newValues = new RouteValueDictionary(routeValues);
            RouteValueDictionary newAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return Form(ajaxHelper, actionName, controllerName, newValues, ajaxOptions, newAttributes);
        }

        public static FormBuilder Form(this AjaxHelper ajaxHelper, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return Form(ajaxHelper, actionName, controllerName, routeValues, ajaxOptions, null /* htmlAttributes */);
        }

        public static FormBuilder Form(this AjaxHelper ajaxHelper, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            // get target URL
            string formAction = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues ?? new RouteValueDictionary(), ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, true /* includeImplicitMvcValues */);
            return FormHelper(ajaxHelper, formAction, ajaxOptions, htmlAttributes);
        }

        public static FormBuilder RouteForm(this AjaxHelper ajaxHelper, string routeName, AjaxOptions ajaxOptions)
        {
            return RouteForm(ajaxHelper, routeName, null /* routeValues */, ajaxOptions, null /* htmlAttributes */);
        }

        public static FormBuilder RouteForm(this AjaxHelper ajaxHelper, string routeName, object routeValues, AjaxOptions ajaxOptions)
        {
            return RouteForm(ajaxHelper, routeName, (object)routeValues, ajaxOptions, null /* htmlAttributes */);
        }

        public static FormBuilder RouteForm(this AjaxHelper ajaxHelper, string routeName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            RouteValueDictionary newAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return RouteForm(ajaxHelper, routeName, new RouteValueDictionary(routeValues), ajaxOptions, newAttributes);
        }

        public static FormBuilder RouteForm(this AjaxHelper ajaxHelper, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return RouteForm(ajaxHelper, routeName, routeValues, ajaxOptions, null /* htmlAttributes */);
        }

        public static FormBuilder RouteForm(this AjaxHelper ajaxHelper, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            string formAction = UrlHelper.GenerateUrl(routeName, null /* actionName */, null /* controllerName */, routeValues ?? new RouteValueDictionary(), ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, false /* includeImplicitMvcValues */);
            return FormHelper(ajaxHelper, formAction, ajaxOptions, htmlAttributes);
        }
        #endregion

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "You don't want to dispose of this object unless you intend to write to the response")]
        private static FormBuilder FormHelper(this AjaxHelper ajaxHelper, string formAction, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            FormBuilder builder = new FormBuilder(ajaxHelper.Marq());
            builder.MergeAttributes(htmlAttributes);
            builder.Attr("action", formAction);
            builder.Attr("method", "post");

            ajaxOptions = GetAjaxOptions(ajaxOptions);

            if (ajaxHelper.ViewContext.UnobtrusiveJavaScriptEnabled)
            {
                builder.MergeAttributes(ajaxOptions.ToUnobtrusiveHtmlAttributes());
            }
            else
            {
                builder.Attr("onclick", FormOnClickValue);
                builder.Attr("onsubmit", GenerateAjaxScript(ajaxOptions, FormOnSubmitFormat));
            }

            if (ajaxHelper.ViewContext.ClientValidationEnabled)
            {
                // forms must have an ID for client validation
                builder.Id(builder.Marquite.GenerateNewId());
            }

            if (ajaxHelper.ViewContext.ClientValidationEnabled)
            {
                ajaxHelper.ViewContext.FormContext.FormId = builder.IdVal;
            }

            return builder;
        }

        public static MvcHtmlString GlobalizationScript(this AjaxHelper ajaxHelper)
        {
            return GlobalizationScript(ajaxHelper, CultureInfo.CurrentCulture);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "ajaxHelper", Justification = "This is an extension method")]
        public static MvcHtmlString GlobalizationScript(this AjaxHelper ajaxHelper, CultureInfo cultureInfo)
        {
            return GlobalizationScriptHelper(AjaxHelper.GlobalizationScriptPath, cultureInfo);
        }

        internal static MvcHtmlString GlobalizationScriptHelper(string scriptPath, CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                throw new ArgumentNullException("cultureInfo");
            }

            TagBuilder tagBuilder = new TagBuilder("script");
            tagBuilder.MergeAttribute("type", "text/javascript");

            string src = VirtualPathUtility.AppendTrailingSlash(scriptPath) + HttpUtility.UrlEncode(cultureInfo.Name) + ".js";
            tagBuilder.MergeAttribute("src", src);

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        #region RouteLink
        public static LinkBuilder RouteLink(this AjaxHelper ajaxHelper, string linkText, object routeValues, AjaxOptions ajaxOptions)
        {
            return RouteLink(ajaxHelper, linkText, null /* routeName */, new RouteValueDictionary(routeValues), ajaxOptions,
                             new Dictionary<string, object>());
        }

        public static LinkBuilder RouteLink(this AjaxHelper ajaxHelper, string linkText, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return RouteLink(ajaxHelper, linkText, null /* routeName */, new RouteValueDictionary(routeValues), ajaxOptions,
                             HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static LinkBuilder RouteLink(this AjaxHelper ajaxHelper, string linkText, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return RouteLink(ajaxHelper, linkText, null /* routeName */, routeValues, ajaxOptions,
                             new Dictionary<string, object>());
        }

        public static LinkBuilder RouteLink(this AjaxHelper ajaxHelper, string linkText, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return RouteLink(ajaxHelper, linkText, null /* routeName */, routeValues, ajaxOptions, htmlAttributes);
        }

        public static LinkBuilder RouteLink(this AjaxHelper ajaxHelper, string linkText, string routeName, AjaxOptions ajaxOptions)
        {
            return RouteLink(ajaxHelper, linkText, routeName, new RouteValueDictionary(), ajaxOptions,
                             new Dictionary<string, object>());
        }

        public static LinkBuilder RouteLink(this AjaxHelper ajaxHelper, string linkText, string routeName, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return RouteLink(ajaxHelper, linkText, routeName, new RouteValueDictionary(), ajaxOptions, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static LinkBuilder RouteLink(this AjaxHelper ajaxHelper, string linkText, string routeName, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return RouteLink(ajaxHelper, linkText, routeName, new RouteValueDictionary(), ajaxOptions, htmlAttributes);
        }

        public static LinkBuilder RouteLink(this AjaxHelper ajaxHelper, string linkText, string routeName, object routeValues, AjaxOptions ajaxOptions)
        {
            return RouteLink(ajaxHelper, linkText, routeName, new RouteValueDictionary(routeValues), ajaxOptions,
                             new Dictionary<string, object>());
        }

        public static LinkBuilder RouteLink(this AjaxHelper ajaxHelper, string linkText, string routeName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return RouteLink(ajaxHelper, linkText, routeName, new RouteValueDictionary(routeValues), ajaxOptions,
                             HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static LinkBuilder RouteLink(this AjaxHelper ajaxHelper, string linkText, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return RouteLink(ajaxHelper, linkText, routeName, routeValues, ajaxOptions, new Dictionary<string, object>());
        }

        public static LinkBuilder RouteLink(this AjaxHelper ajaxHelper, string linkText, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(linkText))
            {
                throw new ArgumentException("Value cannot be null or empty.", "linkText");
            }

            string targetUrl = UrlHelper.GenerateUrl(routeName, null /* actionName */, null /* controllerName */, routeValues ?? new RouteValueDictionary(), ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, false /* includeImplicitMvcValues */);

            return GenerateLink(ajaxHelper, linkText, targetUrl, GetAjaxOptions(ajaxOptions), htmlAttributes);
        }

        public static LinkBuilder RouteLink(this AjaxHelper ajaxHelper, string linkText, string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(linkText))
            {
                throw new ArgumentException("Value cannot be null or empty.", "linkText");
            }

            string targetUrl = UrlHelper.GenerateUrl(routeName, null /* actionName */, null /* controllerName */, protocol, hostName, fragment, routeValues ?? new RouteValueDictionary(), ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, false /* includeImplicitMvcValues */);

            return GenerateLink(ajaxHelper, linkText, targetUrl, GetAjaxOptions(ajaxOptions), htmlAttributes);
        }

        private static LinkBuilder GenerateLink(AjaxHelper ajaxHelper, string linkText, string targetUrl, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            LinkBuilder tag = new LinkBuilder(ajaxHelper.Marq());
            tag.TrailingText(HttpUtility.HtmlEncode(linkText));
            
            tag.MergeAttributes(htmlAttributes);
            tag.Attr("href", targetUrl);

            if (ajaxHelper.ViewContext.UnobtrusiveJavaScriptEnabled)
            {
                tag.MergeAttributes(ajaxOptions.ToUnobtrusiveHtmlAttributes());
            }
            else
            {
                tag.Attr("onclick", GenerateAjaxScript(ajaxOptions, LinkOnClickFormat));
            }

            return tag;
        }
        #endregion

        private static string GenerateAjaxScript(AjaxOptions ajaxOptions, string scriptFormat)
        {
            string optionsString = ajaxOptions.ToJsString();
            return String.Format(CultureInfo.InvariantCulture, scriptFormat, optionsString);
        }

        private static AjaxOptions GetAjaxOptions(AjaxOptions ajaxOptions)
        {
            return ajaxOptions ?? new AjaxOptions();
        }

        private static readonly MethodInfo _toJsStringMethod =
            typeof(AjaxOptions).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Single(c => c.Name == "ToJavascriptString");
        private static string ToJsString(this AjaxOptions options)
        {
            // small hack
            return (string) _toJsStringMethod.Invoke(options, null);
        }
    }
}

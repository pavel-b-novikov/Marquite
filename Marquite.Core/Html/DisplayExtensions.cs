using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Marquite.Core.Html
{
    public static class DisplayExtensions
    {
        public static MvcHtmlString Display(this HtmlHelper html, string expression)
        {
            return System.Web.Mvc.Html.DisplayExtensions.Display(html, expression);
        }

        public static MvcHtmlString Display(this HtmlHelper html, string expression, object additionalViewData)
        {
            return System.Web.Mvc.Html.DisplayExtensions.Display(html, expression, additionalViewData);
        }

        public static MvcHtmlString Display(this HtmlHelper html, string expression, string templateName)
        {
            return System.Web.Mvc.Html.DisplayExtensions.Display(html, expression, templateName);
        }

        public static MvcHtmlString Display(this HtmlHelper html, string expression, string templateName, object additionalViewData)
        {
            return System.Web.Mvc.Html.DisplayExtensions.Display(html, expression, templateName, additionalViewData);
        }

        public static MvcHtmlString Display(this HtmlHelper html, string expression, string templateName, string htmlFieldName)
        {
            return System.Web.Mvc.Html.DisplayExtensions.Display(html, expression, templateName, htmlFieldName);
        }

        public static MvcHtmlString Display(this HtmlHelper html, string expression, string templateName, string htmlFieldName, object additionalViewData)
        {
            return System.Web.Mvc.Html.DisplayExtensions.Display(html, expression, templateName, htmlFieldName, additionalViewData);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString DisplayFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return System.Web.Mvc.Html.DisplayExtensions.DisplayFor<TModel, TValue>(html, expression);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString DisplayFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object additionalViewData)
        {
            return System.Web.Mvc.Html.DisplayExtensions.DisplayFor<TModel, TValue>(html, expression, additionalViewData);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString DisplayFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string templateName)
        {
            return System.Web.Mvc.Html.DisplayExtensions.DisplayFor<TModel, TValue>(html, expression, templateName);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString DisplayFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string templateName, object additionalViewData)
        {
            return System.Web.Mvc.Html.DisplayExtensions.DisplayFor<TModel, TValue>(html, expression, templateName, additionalViewData);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString DisplayFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string templateName, string htmlFieldName)
        {
            return System.Web.Mvc.Html.DisplayExtensions.DisplayFor<TModel, TValue>(html, expression, templateName, htmlFieldName);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString DisplayFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string templateName, string htmlFieldName, object additionalViewData)
        {
            return System.Web.Mvc.Html.DisplayExtensions.DisplayFor<TModel, TValue>(html, expression, templateName, htmlFieldName, additionalViewData);
        }

        public static MvcHtmlString DisplayForModel(this HtmlHelper html)
        {
            return System.Web.Mvc.Html.DisplayExtensions.DisplayForModel(html);
        }

        public static MvcHtmlString DisplayForModel(this HtmlHelper html, object additionalViewData)
        {
            return System.Web.Mvc.Html.DisplayExtensions.DisplayForModel(html, additionalViewData);
        }

        public static MvcHtmlString DisplayForModel(this HtmlHelper html, string templateName)
        {
            return System.Web.Mvc.Html.DisplayExtensions.DisplayForModel(html, templateName);
        }

        public static MvcHtmlString DisplayForModel(this HtmlHelper html, string templateName, object additionalViewData)
        {
            return System.Web.Mvc.Html.DisplayExtensions.DisplayForModel(html, templateName, additionalViewData);
        }

        public static MvcHtmlString DisplayForModel(this HtmlHelper html, string templateName, string htmlFieldName)
        {
            return System.Web.Mvc.Html.DisplayExtensions.DisplayForModel(html, templateName, htmlFieldName);
        }

        public static MvcHtmlString DisplayForModel(this HtmlHelper html, string templateName, string htmlFieldName, object additionalViewData)
        {
            return System.Web.Mvc.Html.DisplayExtensions.DisplayForModel(html, templateName, htmlFieldName, additionalViewData);
        }
    }
}

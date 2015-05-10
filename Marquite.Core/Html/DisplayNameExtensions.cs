using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Marquite.Core.Html
{
    public static class DisplayNameExtensions
    {
        public static MvcHtmlString DisplayName(this HtmlHelper html, string expression)
        {
            return System.Web.Mvc.Html.DisplayNameExtensions.DisplayName(html, expression);
        }

        
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString DisplayNameFor<TModel, TValue>(this HtmlHelper<IEnumerable<TModel>> html, Expression<Func<TModel, TValue>> expression)
        {
            return System.Web.Mvc.Html.DisplayNameExtensions.DisplayNameFor(html, expression);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "This is an extension method")]
        
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString DisplayNameFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return System.Web.Mvc.Html.DisplayNameExtensions.DisplayNameFor(html, expression);
        }

        public static MvcHtmlString DisplayNameForModel(this HtmlHelper html)
        {
            return System.Web.Mvc.Html.DisplayNameExtensions.DisplayNameForModel(html);
        }
        
    }
}

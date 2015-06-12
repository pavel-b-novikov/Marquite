using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Marquite.Core.Html
{
    public static class ValueExtensions
    {
        public static MvcHtmlString Value(this HtmlHelper html, string name)
        {
            return System.Web.Mvc.Html.ValueExtensions.Value(html, name);
        }

        public static MvcHtmlString Value(this HtmlHelper html, string name, string format)
        {
            return System.Web.Mvc.Html.ValueExtensions.Value(html, name, format);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString ValueFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)
        {
            return System.Web.Mvc.Html.ValueExtensions.ValueFor(html, expression, format: null);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString ValueFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, string format)
        {
            return System.Web.Mvc.Html.ValueExtensions.ValueFor(html, expression, format);
        }

        public static MvcHtmlString ValueForModel(this HtmlHelper html)
        {
            return System.Web.Mvc.Html.ValueExtensions.ValueForModel(html);
        }

        public static MvcHtmlString ValueForModel(this HtmlHelper html, string format)
        {
            return System.Web.Mvc.Html.ValueExtensions.ValueForModel(html, format);
        }
    }
}

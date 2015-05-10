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
    public static class DisplayTextExtensions
    {
        public static MvcHtmlString DisplayText(this HtmlHelper html, string name)
        {
            return System.Web.Mvc.Html.DisplayTextExtensions.DisplayText(html, name);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString DisplayTextFor<TModel, TResult>(this HtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression)
        {
            return System.Web.Mvc.Html.DisplayTextExtensions.DisplayTextFor(html, expression);
        }
    }
}

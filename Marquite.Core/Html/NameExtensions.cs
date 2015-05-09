using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Marquite.Core.Html
{
    public static class NameExtensions
    {
        public static MvcHtmlString Id(this HtmlHelper html, string name)
        {
            return System.Web.Mvc.Html.NameExtensions.Id(html,name);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Users cannot use anonymous methods with the LambdaExpression type")]
        public static MvcHtmlString IdFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)
        {
            return System.Web.Mvc.Html.NameExtensions.IdFor(html,expression);
        }

        public static MvcHtmlString IdForModel(this HtmlHelper html)
        {
            return System.Web.Mvc.Html.NameExtensions.IdForModel(html);
        }

        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", MessageId = "1#", Justification = "This is a shipped API.")]
        public static MvcHtmlString Name(this HtmlHelper html, string name)
        {
            return System.Web.Mvc.Html.NameExtensions.Name(html,name);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Users cannot use anonymous methods with the LambdaExpression type")]
        public static MvcHtmlString NameFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)
        {
            return System.Web.Mvc.Html.NameExtensions.NameFor(html,expression);
        }

        public static MvcHtmlString NameForModel(this HtmlHelper html)
        {
            return System.Web.Mvc.Html.NameExtensions.NameForModel(html);
        }
    }
}

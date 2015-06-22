using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Marquite.Bootstrap.Forms;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Html;

namespace Marquite.Bootstrap.Extensions
{
    public static class InputGroupExtensions
    {
        public static InputGroupBuilder ToInputGroup(this InputElementBuilder inputElement)
        {
            return new InputGroupBuilder(inputElement);
        }

        public static InputGroupBuilder InputGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.TextBoxFor(expression).ToInputGroup();
        }

        public static InputGroupBuilder InputGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format)
        {
            return htmlHelper.TextBoxFor(expression, format).ToInputGroup();
        }

        
        public static InputGroupBuilder InputGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return htmlHelper.TextBoxFor(expression, htmlAttributes).ToInputGroup();
        }

        public static InputGroupBuilder InputGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes)
        {
            return htmlHelper.TextBoxFor(expression, format, htmlAttributes).ToInputGroup();
        }

        
        public static InputGroupBuilder InputGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.TextBoxFor(expression,htmlAttributes).ToInputGroup();
        }

        public static InputGroupBuilder InputGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.TextBoxFor(expression, format, htmlAttributes).ToInputGroup();
        }
    }
}

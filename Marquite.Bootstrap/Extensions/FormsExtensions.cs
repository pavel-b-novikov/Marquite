using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Marquite.Bootstrap.Elements;
using Marquite.Bootstrap.Forms;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Html;

namespace Marquite.Bootstrap.Extensions
{
    public static class FormsExtensions
    {
        /// <summary>
        /// Makes regular form inline (adding bootstrap form-inline)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T Inline<T>(this T t) where T : FormBuilderBase<T>
        {
            var plg = t.Marquite.ResolvePlugin<BootstrapPlugin>();
            plg.IsCurrentFormInline = true;
            return t.AddClass("form-inline");
        }

        public static T InlineForm<T>(this T t) where T : ElementHtmlBuilder<T>
        {
            return t.AddClass("form-inline");
        }

        public static T Horizontal<T>(this T t, int labelWidth = 0, int contentWidth = 0) where T : FormBuilderBase<T>
        {
            var plg = t.Marquite.ResolvePlugin<BootstrapPlugin>();
            plg.IsCurrentFormHorizontal = true;
            plg.CurrentFormLabelWidth = labelWidth;
            plg.CurrentFormContentWidth = contentWidth;
            return t.AddClass("form-horizontal");
        }

        public static T HorizontalForm<T>(this T t, int labelWidth = 0, int contentWidth = 0) where T : ElementHtmlBuilder<T>
        {
            var plg = t.Marquite.ResolvePlugin<BootstrapPlugin>();
            plg.CurrentFormLabelWidth = labelWidth;
            plg.CurrentFormContentWidth = contentWidth;
            return t.AddClass("form-horizontal");
        }

        public static BootstrapCheckboxBuilder ToBootstrapCheckbox(this InputElementBuilder t)
        {
            return new BootstrapCheckboxBuilder(t);
        }

        public static FormGroupBuilder FormGroup(this BootstrapPlugin bs, InputElementBuilder inputElement)
        {
            return new FormGroupBuilder(bs.Marquite).WithControl(inputElement);
        }
        public static FormGroupBuilder FormGroup(this BootstrapPlugin bs, InputElementBuilder inputElement, LabelBuilder label)
        {
            return new FormGroupBuilder(bs.Marquite).WithControl(inputElement).WithLabel(label);
        }
        public static FormGroupBuilder ToFormGroup(this InputElementBuilder bs)
        {
            return new FormGroupBuilder(bs.Marquite).WithControl(bs);
        }
        public static FormGroupBuilder ToFormGroup(this InputElementBuilder bs, LabelBuilder label)
        {
            return new FormGroupBuilder(bs.Marquite).WithControl(bs).WithLabel(label);
        }

        public static FormGroupBuilder FormGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var inputElement = htmlHelper.TextBoxFor(expression);
            var labelElement = htmlHelper.LabelFor(expression);
            return htmlHelper.Bs().FormGroup(inputElement, labelElement);
        }

        public static FormGroupBuilder FormGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format)
        {
            var inputElement = htmlHelper.TextBoxFor(expression, format);
            var labelElement = htmlHelper.LabelFor(expression);
            return htmlHelper.Bs().FormGroup(inputElement, labelElement);
        }


        public static FormGroupBuilder FormGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var inputElement = htmlHelper.TextBoxFor(expression, htmlAttributes);
            var labelElement = htmlHelper.LabelFor(expression);
            return htmlHelper.Bs().FormGroup(inputElement, labelElement);
        }

        public static FormGroupBuilder FormGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes)
        {
            var inputElement = htmlHelper.TextBoxFor(expression, format, htmlAttributes);
            var labelElement = htmlHelper.LabelFor(expression);
            return htmlHelper.Bs().FormGroup(inputElement, labelElement);
        }


        public static FormGroupBuilder FormGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            var inputElement = htmlHelper.TextBoxFor(expression, htmlAttributes);
            var labelElement = htmlHelper.LabelFor(expression);
            return htmlHelper.Bs().FormGroup(inputElement, labelElement);
        }

        public static FormGroupBuilder FormGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, IDictionary<string, object> htmlAttributes)
        {
            var inputElement = htmlHelper.TextBoxFor(expression, format, htmlAttributes);
            var labelElement = htmlHelper.LabelFor(expression);
            return htmlHelper.Bs().FormGroup(inputElement, labelElement);
        }
    }
}

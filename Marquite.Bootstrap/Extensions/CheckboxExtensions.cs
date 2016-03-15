using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Marquite.Bootstrap.Elements;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Elements;
using Marquite.Core.Html;

namespace Marquite.Bootstrap.Extensions
{
    public static class CheckboxExtensions
    {
        public static BootstrapCheckableBuilder BootstrapCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> expression, Action<InputElementBuilder> checkbox = null)
        {
            var input = htmlHelper.CheckBoxFor(expression);
            input.Mixin(checkbox);
            var label = htmlHelper.LabelFor(expression);
            label.Prepend(input);
            BootstrapCheckableBuilder builder = new BootstrapCheckableBuilder(input.Marquite);
            builder.AddClass("checkbox");
            builder.Append(label);
            return builder;
        }
        public static BootstrapCheckableBuilder ToBootstrapCheckbox(this IInputField inputElement, string label = null)
        {
            LabelBuilder lb = string.IsNullOrEmpty(label)
                ? null
                : BasicHtmlBuilderExtensions.AppendText(new LabelBuilder(inputElement.Marquite), label);
            return BootstrapCheckable(inputElement, "checkbox", lb);
        }

        public static BootstrapCheckableBuilder ToBootstrapRadio(this IInputField inputElement, string label = null)
        {
            LabelBuilder lb = string.IsNullOrEmpty(label)
                ? null
                : BasicHtmlBuilderExtensions.AppendText(new LabelBuilder(inputElement.Marquite), label);
            return BootstrapCheckable(inputElement, "radio", lb);
        }

        public static BootstrapCheckableBuilder ToBootstrapCheckbox(this IInputField inputElement, LabelBuilder label)
        {
            return BootstrapCheckable(inputElement, "checkbox", label);
        }

        public static BootstrapCheckableBuilder ToBootstrapRadio(this IInputField inputElement, LabelBuilder label)
        {
            return BootstrapCheckable(inputElement, "radio", label);
        }

        private static BootstrapCheckableBuilder BootstrapCheckable(IInputField inputElement, string clazz, LabelBuilder label = null)
        {
            if (!inputElement.FieldType.IsCheckable())
                throw new Exception("Could not make bootstrap checkbox from non-checkable input field");

            BootstrapCheckableBuilder builder = new BootstrapCheckableBuilder(inputElement.Marquite);
            builder.AddClass(clazz);
            if (label == null)
            {
                label = new LabelBuilder(inputElement.Marquite);
            }
            label.Prepend(inputElement);
            builder.Append(label);
            return builder;
        }
    }
}

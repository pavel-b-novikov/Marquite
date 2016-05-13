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
using InputType = Marquite.Core.Elements.InputType;

namespace Marquite.Bootstrap.Extensions
{
    public static class CheckboxExtensions
    {
        public static BootstrapCheckableBuilder Checkbox(this BootstrapPlugin p, Action<LabelBuilder> label = null,
            Action<BaseInputField> input = null)
        {
            var inputElement = new InputElementBuilder(p.Marquite).Type(InputType.CheckBox).Mixin(input);
            var labelElement = new LabelBuilder(p.Marquite).Mixin(label);
            BootstrapCheckableBuilder builder = new BootstrapCheckableBuilder(p.Marquite);
            labelElement.Content(c => c.Prepend(inputElement));
            builder.Content(c => c.Append(labelElement));
            return builder;
        }

        public static BootstrapCheckableBuilder Checkbox(this BootstrapPlugin p, string labelText, Action<LabelBuilder> label = null,
           Action<BaseInputField> input = null)
        {
            return p.Checkbox(a => a.Content(c => c.AppendText(labelText)).Mixin(label), input);
        }


        public static BootstrapCheckableBuilder BsCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> expression, Action<InputElementBuilder> checkbox = null)
        {
            var input = htmlHelper.CheckBoxFor(expression);
            input.Mixin(checkbox);
            var label = htmlHelper.LabelFor(expression);
            label.Content(c => c.Prepend(input));
            BootstrapCheckableBuilder builder = new BootstrapCheckableBuilder(input.Marquite);
            builder.AddClass("checkbox");
            builder.Content(c => c.Append(label));
            return builder;
        }
        public static BootstrapCheckableBuilder ToBootstrapCheckbox(this BaseInputField inputElement, string label = null)
        {
            LabelBuilder lb = string.IsNullOrEmpty(label)
                ? null
                : new LabelBuilder(inputElement.Marquite).Content(c => c.AppendText(label));
            return BootstrapCheckable(inputElement, "checkbox", lb);
        }

        public static BootstrapCheckableBuilder ToBootstrapRadio(this BaseInputField inputElement, string label = null)
        {
            LabelBuilder lb = string.IsNullOrEmpty(label)
                ? null
                : new LabelBuilder(inputElement.Marquite).Content(c => c.AppendText(label));
            return BootstrapCheckable(inputElement, "radio", lb);
        }

        public static BootstrapCheckableBuilder ToBootstrapCheckbox(this BaseInputField inputElement, LabelBuilder label)
        {
            return BootstrapCheckable(inputElement, "checkbox", label);
        }

        public static BootstrapCheckableBuilder ToBootstrapRadio(this BaseInputField inputElement, LabelBuilder label)
        {
            return BootstrapCheckable(inputElement, "radio", label);
        }

        private static BootstrapCheckableBuilder BootstrapCheckable(BaseInputField inputElement, string clazz, LabelBuilder label = null)
        {
            if (!inputElement.FieldType.IsCheckable())
                throw new Exception("Could not make bootstrap checkbox from non-checkable input field");

            BootstrapCheckableBuilder builder = new BootstrapCheckableBuilder(inputElement.Marquite);
            builder.AddClass(clazz);
            if (label == null)
            {
                label = new LabelBuilder(inputElement.Marquite);
            }
            label.Content(c => c.Prepend(inputElement));
            builder.Content(c => c.Append(label));
            return builder;
        }
    }
}

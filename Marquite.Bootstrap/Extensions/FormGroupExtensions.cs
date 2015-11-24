using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Marquite.Bootstrap.Forms;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Html;

namespace Marquite.Bootstrap.Extensions
{
    public static class FormGroupExtensions
    {
        private static T Apply<T>(this Func<T, T> func, T arg)
        {
            return func == null ? arg : func(arg);
        }

        public static FormGroupBuilder AddLabel(this FormGroupBuilder b, string label, int width = 0, int offset = 0)
        {
            b.AddElement(new LabelBuilder(b.Marquite).TrailingText(label), width, offset);
            return b;
        }


        public static FormGroupBuilder AddStatic(this FormGroupBuilder b, string staticContent, int width = 0, int offset = 0)
        {
            b.AddElement(new SimpleHtmlBuilder(b.Marquite, "p").AddClass("form-control-static").TrailingText(staticContent), width, offset);
            return b;
        }
        public static FormGroupBuilder FormGroup(this HtmlHelper b)
        {
            return new FormGroupBuilder(b.Marq());
        }

        public static FormGroupBuilder FormGroupDisplayFor<TModel, TData>(this HtmlHelper<TModel> b, Expression<Func<TModel, TData>> expression,
            int labelWidth = 0, int fieldWidth = 0)
        {
            var line = new FormGroupBuilder(b.Marq());
            var bs = line.Marquite.ResolvePlugin<BootstrapPlugin>();
            if (labelWidth == 0) labelWidth = bs.CurrentFormLabelWidth;
            if (fieldWidth == 0) fieldWidth = bs.CurrentFormContentWidth;
            var label = b.LabelFor(expression);
            line.AddElement(label, labelWidth);
            line.AddStatic(b.DisplayFor(expression).ToString(),fieldWidth);
            return line;
        }

        public static FormGroupBuilder FormGroupTextFor<TModel, TData>(this HtmlHelper<TModel> b, Expression<Func<TModel, TData>> expression,
            Func<InputElementBuilder,InputElementBuilder> withInput = null,
            Func<LabelBuilder, LabelBuilder> withLabel = null,
            int labelWidth = 0, int fieldWidth = 0)
        {
            return FormGroupBuilderFor(
                withInput.Apply(b.TextBoxFor(expression)), 
                withLabel.Apply(b.LabelFor(expression)), 
                labelWidth, fieldWidth);
        }

        public static FormGroupBuilder FormGroupDropdownFor<TModel, TData>(this HtmlHelper<TModel> b, Expression<Func<TModel, TData>> expression,
            IEnumerable<SelectListItem> listItems,
            Func<SelectBuilder, SelectBuilder> withSelect = null,
            Func<LabelBuilder, LabelBuilder> withLabel = null,
            int labelWidth = 0, int fieldWidth = 0)
        {
            return FormGroupBuilderFor(
                withSelect.Apply(b.DropDownListFor(expression, listItems)), 
                withLabel.Apply(b.LabelFor(expression))
                , labelWidth, fieldWidth);
        }

        public static FormGroupBuilder FormGroupCheckboxFor<TModel>(this HtmlHelper<TModel> b, Expression<Func<TModel, bool>> expression,
            int fieldWidth = 0)
        {
            return FormGroupBuilderFor(b.CheckBoxFor(expression).ToBootstrapCheckbox(b.LabelFor(expression)), null, 0, fieldWidth);
        }

        private static FormGroupBuilder FormGroupBuilderFor(IHtmlBuilder input, LabelBuilder labelFor, int labelWidth = 0, int fieldWidth = 0)
        {
            var line = new FormGroupBuilder(input.Marquite);
            var bs = line.Marquite.ResolvePlugin<BootstrapPlugin>();
            if (labelWidth == 0) labelWidth = bs.CurrentFormLabelWidth;
            if (fieldWidth == 0) fieldWidth = bs.CurrentFormContentWidth;
            if (labelFor != null)
            {
                line.AddElement(labelFor, labelWidth);
                line.AddElement(input, fieldWidth);
            }
            else
            {
                line.AddElement(input, fieldWidth, labelWidth);
            }
            return line;
        }
    }
}

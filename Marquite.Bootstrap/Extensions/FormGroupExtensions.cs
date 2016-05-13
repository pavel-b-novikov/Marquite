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
    public static class FormGroupExtensions
    {
        public static FormGroupBuilder AddLabel(this FormGroupBuilder b, string label, int width = 0, int offset = 0,Action<LabelBuilder> labelOptions = null )
        {
            var lbl = new LabelBuilder(b.Marquite).Content(c => c.AppendText(label));
            lbl.Mixin(labelOptions);
            b.AddElement(lbl, width, offset);
            return b;
        }

        public static SimpleHtmlBuilder FormGroupStatic(this BootstrapPlugin bs, string staticContent)
        {
            return new SimpleHtmlBuilder(bs.Marquite, "p").AddClass("form-control-static").Content(c => c.AppendText(staticContent));
        }

        public static FormGroupBuilder AddStatic(this FormGroupBuilder b, string staticContent, int width = 0, int offset = 0,Action<SimpleHtmlBuilder> staticContentOptions = null)
        {
            var statics =b.Bootstrap.FormGroupStatic(staticContent);
            statics.Mixin(staticContentOptions);
            b.AddElement(statics, width, offset);
            return b;
        }

        public static FormGroupBuilder AddStatic(this FormGroupBuilder b, string label, string staticContent, int width = 0, int offset = 0, Action<SimpleHtmlBuilder> staticContentOptions = null, Action<LabelBuilder> labelOptions = null)
        {
            var lbl = new LabelBuilder(b.Marquite).Content(c => c.AppendText(label));
            lbl.Mixin(labelOptions);
            var statics =
                new SimpleHtmlBuilder(b.Marquite, "p").AddClass("form-control-static").Content(c => c.AppendText(staticContent));
            statics.Mixin(staticContentOptions);
            b.AddElement(lbl,statics);
            return b;
        }
        public static FormGroupBuilder BsFormGroup(this HtmlHelper b)
        {
            return new FormGroupBuilder(b.Marq());
        }

        public static FormGroupBuilder BsFormGroupDisplayFor<TModel, TData>(this HtmlHelper<TModel> b, Expression<Func<TModel, TData>> expression,
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

        public static FormGroupBuilder BsFormGroupTextFor<TModel, TData>(this HtmlHelper<TModel> b, Expression<Func<TModel, TData>> expression,
            Func<InputElementBuilder,InputElementBuilder> withInput = null,
            Func<LabelBuilder, LabelBuilder> withLabel = null,
            int labelWidth = 0, int fieldWidth = 0)
        {
            return FormGroupBuilderFor(
                b.TextBoxFor(expression).Mixin(withInput),
                b.LabelFor(expression).Mixin(withLabel), 
                labelWidth, fieldWidth);
        }

        public static FormGroupBuilder BsFormGroupTextareaFor<TModel, TData>(this HtmlHelper<TModel> h,
            Expression<Func<TModel, TData>> expression,Action<LabelBuilder> label = null,Action<TextareaBuilder> textarea = null,int labelWidth = 0, int fieldWidth = 0)
        {
            if (labelWidth == 0) labelWidth = h.Bs().CurrentFormLabelWidth;
            if (fieldWidth == 0) fieldWidth = h.Bs().CurrentFormContentWidth;
            return h.BsFormGroup()
                .AddElement(h.LabelFor(expression), labelWidth)
                .AddElement(h.TextAreaFor(expression), fieldWidth);
        }
        public static FormGroupBuilder BsFormGroupDropdownFor<TModel, TData>(this HtmlHelper<TModel> b, Expression<Func<TModel, TData>> expression,
            IEnumerable<SelectListItem> listItems,
            Func<SelectBuilder, SelectBuilder> withSelect = null,
            Func<LabelBuilder, LabelBuilder> withLabel = null,
            int labelWidth = 0, int fieldWidth = 0)
        {
            return FormGroupBuilderFor(
                (b.DropDownListFor(expression, listItems)).Mixin(withSelect),
                (b.LabelFor(expression)).Mixin(withLabel)
                , labelWidth, fieldWidth);
        }

        public static FormGroupBuilder BsFormGroupCheckboxFor<TModel>(this HtmlHelper<TModel> b, Expression<Func<TModel, bool>> expression,
            int fieldWidth = 0)
        {
            return FormGroupBuilderFor(b.CheckBoxFor(expression).ToBootstrapCheckbox(b.LabelFor(expression)), null, 0, fieldWidth);
        }



        private static FormGroupBuilder FormGroupBuilderFor(BasicHtmlBuilder input, LabelBuilder labelFor, int labelWidth = 0, int fieldWidth = 0)
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

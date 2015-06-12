using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Bootstrap.Elements;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;

namespace Marquite.Bootstrap.Extensions
{
    public static class FormsExtensions
    {
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

        public static T Horizontal<T>(this T t, int labelWidth = 0,int contentWidth = 0) where T : FormBuilderBase<T>
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
    }
}

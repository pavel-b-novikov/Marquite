using Marquite.Bootstrap.Elements;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Elements;

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
        public static T Inline<T>(this T t) where T : FormBuilder
        {
            var plg = t.Marquite.ResolvePlugin<BootstrapPlugin>();
            plg.IsCurrentFormInline = true;
            return t.AddClass("form-inline");
        }

        public static T InlineForm<T>(this T t) where T : ElementHtmlBuilder
        {
            return t.AddClass("form-inline");
        }

        public static T Horizontal<T>(this T t, int labelWidth = 0, int contentWidth = 0) where T : FormBuilder
        {
            var plg = t.Marquite.ResolvePlugin<BootstrapPlugin>();
            plg.IsCurrentFormHorizontal = true;
            plg.CurrentFormLabelWidth = labelWidth;
            plg.CurrentFormContentWidth = contentWidth;
            return t.AddClass("form-horizontal");
        }

        public static T HorizontalForm<T>(this T t, int labelWidth = 0, int contentWidth = 0) where T : ElementHtmlBuilder
        {
            var plg = t.Marquite.ResolvePlugin<BootstrapPlugin>();
            plg.IsCurrentFormHorizontal = true;
            plg.CurrentFormLabelWidth = labelWidth;
            plg.CurrentFormContentWidth = contentWidth;
            return t.AddClass("form-horizontal");
        }
    }
}

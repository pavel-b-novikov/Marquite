using System;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.Html
{
    public interface ITextable { }
    public interface IDisableable { }
    public interface IValuable { }
    public interface INameable { }
    public interface ILabelable { }

    public interface IFieldset : INameable, IDisableable { }

    public static class CommonBuildersExtensions
    {
        public static T Value<T>(this T b, string value) where T : BasicHtmlBuilder,IValuable
        {
            return b.Attr("value", value);
        }

        public static T Value<T>(this T b, object value) where T : BasicHtmlBuilder, IValuable
        {
            return b.Attr("value", value.ToString());
        }

        public static T Value<T>(this T b, object value, string format) where T : BasicHtmlBuilder, IValuable
        {
            return b.Attr("value", String.Format(format, value));
        }

        public static T Text<T>(this T b, string text) where T : BasicHtmlBuilder, ITextable
        {
            return b.Content(c => c.AppendText(text));
        }

        public static T Disabled<T>(this T b) where T : BasicHtmlBuilder, IDisableable
        {
            return b.SelfCloseAttr("disabled");
        }

        public static T Name<T>(this T b, string fieldName) where T : BasicHtmlBuilder, INameable
        {
            return b.Attr("name", fieldName);
        }

        public static T LabelAttr<T>(this T b, string label) where T : BasicHtmlBuilder, ILabelable
        {
            return b.Attr("label", label);
        }
    }
}

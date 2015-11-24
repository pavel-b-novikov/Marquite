using System;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.Html
{
    public interface ITextable : IHtmlBuilder { }
    public interface IDisableable : IHtmlBuilder { }
    public interface IValuable : IHtmlBuilder { }
    public interface INameable : IHtmlBuilder { }
    public interface ILabelable : IHtmlBuilder { }

    public static class CommonBuildersExtensions
    {
        public static T Value<T>(this T b, string value) where T : IValuable
        {
            return b.Attr("value", value);
        }

        public static T Value<T>(this T b, object value) where T : IValuable
        {
            return b.Attr("value", value.ToString());
        }

        public static T Value<T>(this T b, object value, string format) where T : IValuable
        {
            return b.Attr("value", String.Format(format, value));
        }

        public static T Text<T>(this T b, string text) where T : ITextable
        {
            return b.TrailingText(text);
        }

        public static T Disabled<T>(this T b) where T : IDisableable
        {
            return b.SelfCloseAttr("disabled");
        }

        public static T Name<T>(this T b, string fieldName) where T : INameable
        {
            return b.Attr("name", fieldName);
        }

        public static T Label<T>(this T b, string label) where T : ILabelable
        {
            return b.Attr("label", label);
        }
    }
}

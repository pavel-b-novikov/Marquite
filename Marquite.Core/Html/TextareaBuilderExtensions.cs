using System;
using Marquite.Core.Elements;

namespace Marquite.Core.Html
{
    public static class TextareaBuilderExtensions
    {
        public static T Rows<T>(this T b, int rows) where T : TextareaBuilder
        {
            if (rows < 0) throw new ArgumentException("Rows number cannot be less than zero", "rows");
            return b.Attr("rows", rows.ToString());
        }

        public static T Cols<T>(this T b, int cols) where T : TextareaBuilder
        {
            if (cols < 0) throw new ArgumentException("Cols number cannot be less than zero", "cols");
            return b.Attr("cols", cols.ToString());
        }

        public static T Maxlength<T>(this T b, int max) where T : TextareaBuilder
        {
            return b.Attr("maxlength", max.ToString());
        }

        public static T Wrap<T>(this T b, TextAreaWrap wrapping) where T : TextareaBuilder
        {
            return b.Attr("wrap", Lookups.Lookup(wrapping));
        }

        public static T Placeholder<T>(this T b, string value) where T : TextareaBuilder
        {
            return b.Attr("placeholder", value);
        }

        public static T Placeholder<T>(this T b, object value) where T : TextareaBuilder
        {
            return b.Attr("placeholder", value.ToString());
        }

        public static T Placeholder<T>(this T b, object value, string format) where T : TextareaBuilder
        {
            return b.Attr("placeholder", String.Format(format, value));
        }
    }
}
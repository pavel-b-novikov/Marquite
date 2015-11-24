using System;
using Marquite.Core.Elements;

namespace Marquite.Core.Html
{
    public static class InputElementExtensions
    {
        public static T Placeholder<T>(this T b,string value) where T : InputElementBuilder 
        {
            var t = b.GetAttr("type");
            if (t != "text" && t != "password") throw new Exception("Non-text fields should not contain placeholder");
            return b.Attr("placeholder", value);
        }

        public static T Placeholder<T>(this T b,object value) where T : InputElementBuilder 
        {
            var t = b.GetAttr("type");
            if (t != "text" && t != "password") throw new Exception("Non-text fields should not contain placeholder");
            return b.Attr("placeholder", value.ToString());
        }

        public static T Placeholder<T>(this T b, object value, string format) where T : InputElementBuilder 
        {
            var t = b.GetAttr("type");
            if (t != "text" && t != "password") throw new Exception("Non-text fields should not contain placeholder");
            return b.Attr("placeholder", String.Format(format, value));
        }
        
        public static T Type<T>(this T b,InputType type) where T : InputElementBuilder 
        {
            b.FieldType = (MarquiteInputType) type;
            return b.Attr("type", Lookups.Lookup(type));
        }

        public static T Checked<T>(this T b) where T : InputElementBuilder 
        {
            var t = b.GetAttr("type");
            if (t != "checkbox" && t != "radio") throw new Exception("Only checkboxes and radios can be checked");
            return b.Attr("checked", "checked");
        }

        public static T Unchecked<T>(this T b) where T : InputElementBuilder 
        {
            var t = b.GetAttr("type");
            if (t != "checkbox" && t != "radio") throw new Exception("Only checkboxes and radios can be checked");
            return b.RemoveAttr("checked");
        }

    }
}
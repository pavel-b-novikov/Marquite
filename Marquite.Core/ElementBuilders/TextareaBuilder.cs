using System;

namespace Marquite.Core.ElementBuilders
{
    public class TextareaBuilder : BaseInputField<TextareaBuilder>, IInputField
    {
        public TextareaBuilder(Marquite marquite) : base(marquite, "textarea")
        {
        }
        
        public TextareaBuilder Rows(int rows)
        {
            if (rows<0) throw new ArgumentException("Rows number cannot be less than zero","rows");
            return Attr("rows", rows.ToString());
        }

        public TextareaBuilder Cols(int cols)
        {
            if (cols < 0) throw new ArgumentException("Cols number cannot be less than zero", "cols");
            return Attr("cols", cols.ToString());
        }

        public TextareaBuilder Maxlength(int max)
        {
            return Attr("maxlength", max.ToString());
        }

        public TextareaBuilder Wrap(TextAreaWrap wrapping)
        {
            return Attr("wrap", Lookups.Lookup(wrapping));
        }

        public TextareaBuilder Placeholder(string value)
        {
            return Attr("placeholder", value);
        }

        public TextareaBuilder Placeholder(object value)
        {
            return Attr("placeholder", value.ToString());
        }

        public TextareaBuilder Placeholder(object value, string format)
        {
            return Attr("placeholder", String.Format(format, value));
        }


        public string FieldId { get { return IdVal; } }
        public string FieldName { get { return GetAttr("name"); } }
        public MarquiteInputType FieldType { get { return MarquiteInputType.Textarea; } }
    }

    [LookupEnum]
    public enum TextAreaWrap
    {
        [LookupString("soft")]
        Soft,
        [LookupString("hard")]
        Hard,
        [LookupString("off")]
        Off
    }
}

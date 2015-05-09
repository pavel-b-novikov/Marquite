using System;

namespace Marquite.Core.ElementBuilders
{
    public class TextareaBuilder : BaseInputField<TextareaBuilder>
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

        public TextareaBuilder Placeholder(string placeholder)
        {
            return Attr("placeholder", placeholder);
        }

        public TextareaBuilder Wrap(TextAreaWrap wrapping)
        {
            return Attr("wrap", Lookups.Lookup(wrapping));
        }
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

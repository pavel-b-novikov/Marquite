using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core.ElementBuilders
{
    public class InputElementBuilder : BaseInputField<InputElementBuilder>
    {
        public InputElementBuilder(Marquite marquite) : base(marquite, "input")
        {
            IsSelfClosing = true;
        }

        public InputElementBuilder Value(string value)
        {
            return Attr("value", value);
        }

        public InputElementBuilder Value(object value)
        {
            return Attr("value", value.ToString());
        }

        public InputElementBuilder Value(object value,string format)
        {
            return Attr("value", String.Format(format,value));
        }

        public InputElementBuilder Type(InputType type)
        {
            return Attr("type", Lookups.Lookup(type));
        }

        public InputElementBuilder Checked()
        {
            var t = GetAttr("type");
            if (t!="checkbox"&&t!="radio") throw new Exception("Only checkboxes and radios can be checked");
            return Attr("checked", "checked");
        }

        public InputElementBuilder Unchecked()
        {
            var t = GetAttr("type");
            if (t != "checkbox" && t != "radio") throw new Exception("Only checkboxes and radios can be checked");
            return RemoveAttr("checked");
        }

    }

    [LookupEnum]
    public enum InputType
    {
        [LookupString("text")]
        Text,
        [LookupString("password")]
        Password,
        [LookupString("radio")]
        Radio,
        [LookupString("checkbox")]
        CheckBox,
        [LookupString("button")]
        Button,
        [LookupString("color")]
        Color,
        [LookupString("date")]
        Date,
        [LookupString("datetime")]
        Datetime,
        [LookupString("datetime-local")]
        DatetimeLocal,
        [LookupString("email")]
        Email,
        [LookupString("month")]
        Month,
        [LookupString("number")]
        Number,
        [LookupString("range")]
        Range,
        [LookupString("search")]
        Search,
        [LookupString("tel")]
        Tel,
        [LookupString("time")]
        Time,
        [LookupString("url")]
        Url,
        [LookupString("week")]
        Week,
        [LookupString("hidden")]
        Hidden
    }
}

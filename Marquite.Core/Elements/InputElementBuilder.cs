using Marquite.Core.Html;

namespace Marquite.Core.Elements
{
    public class InputElementBuilder : BaseInputField, IInputField, IValuable
    {
        public InputElementBuilder(IMarquite marquite) : base(marquite, "input")
        {
            IsSelfClosing = true;
            this.Type(InputType.Text);
        }
       
        public string FieldId { get { return IdVal; } }
        public string FieldName { get { return this.GetAttr("name"); } }
        
        public MarquiteInputType FieldType { get; set; }

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

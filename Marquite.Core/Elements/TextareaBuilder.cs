namespace Marquite.Core.Elements
{
    public class TextareaBuilder : BaseInputField,IInputField
    {
        public TextareaBuilder(IMarquite marquite) : base(marquite, "textarea")
        {
        }
        
        
        public string FieldId { get { return IdVal; } }
        public string FieldName { get { return this.GetAttr("name"); } }
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

namespace Marquite.Core.Elements
{
    public class SelectBuilder : BaseInputField, IInputField
    {
        public SelectBuilder(IMarquite marquite) : base(marquite, "select")
        {
        }

        

        public string FieldId { get { return IdVal; } }

        public string FieldName { get { return this.GetAttr("name"); } }
        public MarquiteInputType FieldType { get { return MarquiteInputType.Select; } }
    }
}

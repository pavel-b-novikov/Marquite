namespace Marquite.Core.Elements
{
    public class SelectBuilder : BaseInputField, IInputField
    {
        public SelectBuilder(IMarquite marquite) : base(marquite, "select")
        {
        }

        public override MarquiteInputType FieldType { get { return MarquiteInputType.Select; } }
    }
}

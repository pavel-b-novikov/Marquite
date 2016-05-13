using Marquite.Core.BuilderMechanics;
using Marquite.Core.Html;

namespace Marquite.Core.Elements
{
    public class BaseInputField : ElementHtmlBuilder, IDisableable, INameable, IInputField
    {
        public BaseInputField(IMarquite marquite, string tagName) : base(marquite, tagName)
        {
        }
        public bool IsDisabled { get { return this.ContainsAttr("disabled"); } }
        public virtual string FieldId { get { return IdVal; } }
        public virtual string FieldName { get { return this.GetAttr("name"); } }
        public virtual MarquiteInputType FieldType { get; set; }
    }
}

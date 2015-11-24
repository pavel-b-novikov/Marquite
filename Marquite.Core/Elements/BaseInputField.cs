using Marquite.Core.BuilderMechanics;
using Marquite.Core.Html;

namespace Marquite.Core.Elements
{
    public class BaseInputField : ElementHtmlBuilder, IDisableable, INameable
    {
        public BaseInputField(IMarquite marquite, string tagName) : base(marquite, tagName)
        {
        }
        public bool IsDisabled { get { return this.ContainsAttr("disabled"); } }
    }
}

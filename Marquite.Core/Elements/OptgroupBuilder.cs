using Marquite.Core.BuilderMechanics;
using Marquite.Core.Html;

namespace Marquite.Core.Elements
{
    public class OptgroupBuilder : ElementHtmlBuilder, IDisableable, ILabelable
    {
        public OptgroupBuilder(IMarquite marquite) : base(marquite, "optgroup")
        {
        }
    }
}

using Marquite.Core.BuilderMechanics;
using Marquite.Core.Html;

namespace Marquite.Core.Elements
{
    public class LabelBuilder : ElementHtmlBuilder, ITextable
    {
        public LabelBuilder(IMarquite marquite)
            : base(marquite, "label")
        {
        }

        
    }
}

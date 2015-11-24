using Marquite.Core.BuilderMechanics;
using Marquite.Core.Html;

namespace Marquite.Core.Elements
{
    public class ButtonBuilder : ElementHtmlBuilder, ITextable, IDisableable
    {
        public ButtonBuilder(IMarquite marquite, string tagName)
            : base(marquite, tagName)
        {
        }
    }
}

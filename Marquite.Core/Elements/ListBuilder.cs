using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.Elements
{
    public abstract class ListBuilder : ElementHtmlBuilder
    {
        protected ListBuilder(IMarquite m, string tagName)
            : base(m, tagName)
        {
        }
    }
}
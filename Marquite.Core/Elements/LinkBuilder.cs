using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.Elements
{
    public class LinkBuilder : ElementHtmlBuilder
    {
        public LinkBuilder(IMarquite marquite) : base(marquite, "a")
        {
        }
    }

    [LookupEnum]
    public enum TargetWindowType
    {
        [LookupString("_blank")] Blank,
        [LookupString("_self")] Self,
        [LookupString("_parent")] Parent,
        [LookupString("_top")] Top
    }
}
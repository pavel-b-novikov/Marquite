using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.ElementBuilders
{
    public class LinkBuilder : ElementHtmlBuilder<LinkBuilder>
    {
        public LinkBuilder(Marquite marquite) : base(marquite, "a")
        {
        }

        public LinkBuilder Href(string reference)
        {
            return Attr("href", reference);
        }

        public LinkBuilder Download()
        {
            return SelfCloseAttr("download");
        }

        public LinkBuilder Anchor(string anchorName)
        {
            return Attr("name", anchorName);
        }

        public LinkBuilder Target(string target)
        {
            return Attr("target", target);
        }

        public LinkBuilder Target(TargetWindowType type)
        {
            return Target(Lookups.Lookup(type));
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
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.ElementBuilders
{
    public class LinkBuilder : LinkBuilderBase<LinkBuilder>
    {
        public LinkBuilder(IMarquite marquite) : base(marquite)
        {
        }
    }

    public class LinkBuilderBase<T> : ElementHtmlBuilder<T> where T : LinkBuilderBase<T>
    {
        public LinkBuilderBase(IMarquite marquite) : base(marquite, "a")
        {
        }

        public T Href(string reference)
        {
            return Attr("href", reference);
        }

        public T Download()
        {
            return SelfCloseAttr("download");
        }

        public T Anchor(string anchorName)
        {
            return Attr("name", anchorName);
        }

        public T Target(string target)
        {
            return Attr("target", target);
        }

        public T Target(TargetWindowType type)
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
using Marquite.Core.Elements;

namespace Marquite.Core.Html
{
    public static class LinkBuilderExtensions
    {
        public static T Href<T>(this T b,string reference) where T : LinkBuilder 
        {
            return b.Attr("href", reference);
        }

        public static T Download<T>(this T b) where T : LinkBuilder 
        {
            return b.SelfCloseAttr("download");
        }

        public static T Anchor<T>(this T b,string anchorName) where T : LinkBuilder 
        {
            return b.Attr("name", anchorName);
        }

        public static T Target<T>(this T b,string target) where T : LinkBuilder 
        {
            return b.Attr("target", target);
        }

        public static T Target<T>(this T b,TargetWindowType type) where T : LinkBuilder 
        {
            return Target(b,Lookups.Lookup(type));
        }
    }
}
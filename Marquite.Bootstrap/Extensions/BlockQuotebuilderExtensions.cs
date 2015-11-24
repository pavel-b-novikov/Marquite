using Marquite.Bootstrap.Elements;
using Marquite.Core;

namespace Marquite.Bootstrap.Extensions
{
    public static class BlockQuotebuilderExtensions
    {
        public static T Text<T>(this T b,string text) where T : BlockQuoteBuilder
        {
            b._blockQuoteText = text;
            return b;
        }

        public static T Reverse<T>(this T b) where T : BlockQuoteBuilder
        {
            b.AddClass("blockquote-reverse");
            return b;
        }
    }
}
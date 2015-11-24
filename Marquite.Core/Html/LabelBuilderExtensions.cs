using Marquite.Core.Elements;

namespace Marquite.Core.Html
{
    public static class LabelBuilderExtensions
    {
        public static T For<T>(this T b,string forField) where T: LabelBuilder
        {
            return b.Attr("for", forField);
        }
    }
}
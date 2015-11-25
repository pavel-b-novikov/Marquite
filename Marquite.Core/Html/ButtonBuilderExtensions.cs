using Marquite.Core.Elements;

namespace Marquite.Core.Html
{
    public static class ButtonBuilderExtensions
    {
        public static T Content<T>(this T b, string text) where T : ButtonBuilder
        {
            if (b.TagName == "input")
            {
                if (string.IsNullOrEmpty(text)) b.RemoveAttr("value");
                else b.Attr("value", text);
            }
            else
            {
                b.RenderingQueue.ClearQueue();
                b.RenderingQueue.Trail(text);
            }
            return b;
        }

        public static T AppendButtonText<T>(this T b, string text) where T : ButtonBuilder
        {
            if (string.IsNullOrEmpty(text)) return b;

            if (b.TagName == "input")
            {
                b.Attr("value", b.GetAttr("value") + text);
            }
            else
            {
                b.RenderingQueue.Trail(text);
            }
            return b;
        }

        public static T Submit<T>(this T b) where T : ButtonBuilder
        {
            return b.Attr("type", "submit");
        }
    }
}
using Marquite.Core.Elements;
using Marquite.Core.Rendering;

namespace Marquite.Core.Html
{
    public static class TableRowBuilderExtensions
    {
        public static T AddCell<T>(this T b,string content) where T : TableRowBuilder
        {
            b.Content.Trail(content, "td");
            return b;
        }

        public static T AddCells<T>(this T b, params string[] content) where T : TableRowBuilder
        {
            content.ForEach(c => b.Content.Trail(c, "td"));
            return b;
        }

        public static T AddCell<T>(this T b, IRenderingClient content) where T : TableRowBuilder
        {
            b.Content.Trail(content.Detached(), "td");
            return b;
        }

        public static T AddCells<T>(this T b, params IRenderingClient[] content) where T : TableRowBuilder
        {
            content.ForEach(c => b.Content.Trail(c.Detached(), "td"));
            return b;
        }
    }
}
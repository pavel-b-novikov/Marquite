using Marquite.Core.Elements;
using Marquite.Core.Rendering;

namespace Marquite.Core.Html
{
    public static class TableBuilderExtensions
    {
        #region Heading 0
        public static T AddHeadings<T>(this T b, params string[] columnNames) where T : TableBuilder
        {
            AddHeadings(b, 0, columnNames);
            return b;
        }

        public static T AddHeading<T>(this T b, string columnName) where T : TableBuilder
        {
            AddHeading(b, 0, columnName);
            return b;
        }

        public static T AddHeadings<T>(this T b, params IRenderingClient[] columnHeaderContents) where T : TableBuilder
        {
            AddHeadings(b, 0, columnHeaderContents);
            return b;
        }

        public static T AddHeading<T>(this T b, IRenderingClient columnHeaderContent) where T : TableBuilder
        {
            AddHeading(b,0, columnHeaderContent);
            return b;
        }
        #endregion

        public static T AddHeadings<T>(this T b, int row, params string[] columnNames) where T : TableBuilder
        {
            var tr = b.GetHeadRow(row);
            columnNames.ForEach(c => tr.Trail(c, "td"));
            return b;
        }

        public static T AddHeading<T>(this T b, int row, string columnName) where T : TableBuilder
        {
            var tr = b.GetHeadRow(row);
            tr.Trail(columnName, "td");
            return b;
        }

        public static T AddHeadings<T>(this T b, int row, params IRenderingClient[] columnHeaderContents) where T : TableBuilder
        {
            var tr = b.GetHeadRow(row);
            columnHeaderContents.ForEach(c => tr.Trail(c.Detached(), "td"));
            return b;
        }

        public static T AddHeading<T>(this T b, int row, IRenderingClient columnHeaderContent) where T : TableBuilder
        {
            var tr = b.GetHeadRow(row);
            tr.Trail(columnHeaderContent.Detached(), "td");
            return b;
        }

        public static T DontRenderTbody<T>(this T b) where T : TableBuilder
        {
            b.RenderTbody = false;
            return b;
        }

    }
}
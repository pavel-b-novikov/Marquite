using Marquite.Core.Elements;
using Marquite.Core.Rendering;

namespace Marquite.Core.Html
{
    public static class TableExtensions
    {
        public static TableBuilder Table(this IMarquite m)
        {
            return new TableBuilder(m);
        }

        public static TableBuilder Table(this IMarquite m, params string[] columns)
        {
            var t = new TableBuilder(m);
            t.AddHeadings(columns);
            return t;
        }

        public static TableBuilder Table(this IMarquite m, params IRenderingClient[] columns)
        {
            var t = new TableBuilder(m);
            t.AddHeadings(columns);
            return t;
        }

        public static TableRowBuilder Tr(this IMarquite m)
        {
            return new TableRowBuilder(m);
        }

        public static TableRowBuilder Tr(this IMarquite m, params string[] columns)
        {
            var t = new TableRowBuilder(m);
            t.AddCells(columns);
            return t;
        }

        public static TableRowBuilder Tr(this IMarquite m, params IRenderingClient[] columns)
        {
            var t = new TableRowBuilder(m);
            t.AddCells(columns);
            return t;
        }
    }
}
using Marquite.Bootstrap.Tables;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Extensions
{
    public static class TableExtensions
    {
        public static TableBuilder Table(this Core.Marquite m)
        {
            return new TableBuilder(m);
        }

        public static TableBuilder Table(this Core.Marquite m, params string[] columns)
        {
            var t = new TableBuilder(m);
            t.AddHeadings(columns);
            return t;
        }

        public static TableBuilder Table(this Core.Marquite m, params IRenderingClient[] columns)
        {
            var t = new TableBuilder(m);
            t.AddHeadings(columns);
            return t;
        }


        public static TableRowBuilder Tr(this Core.Marquite m)
        {
            return new TableRowBuilder(m);
        }

        public static TableRowBuilder Tr(this Core.Marquite m, params string[] columns)
        {
            var t = new TableRowBuilder(m);
            t.AddCells(columns);
            return t;
        }

        public static TableRowBuilder Tr(this Core.Marquite m, params IRenderingClient[] columns)
        {
            var t = new TableRowBuilder(m);
            t.AddCells(columns);
            return t;
        }
    }
}

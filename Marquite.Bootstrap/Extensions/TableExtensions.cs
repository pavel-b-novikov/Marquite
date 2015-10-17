using Marquite.Core.ElementBuilders;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Extensions
{
    public static class TableExtensions
    {
        private static void EnsureTableClass(TableBuilder table)
        {
            var tbl = Lookups.Lookup(TableClasses.Table);
            table.AddClass(tbl);
        }
        public static TableBuilder Stripped(this TableBuilder table)
        {
            EnsureTableClass(table);
            var str = Lookups.Lookup(TableClasses.Striped);
            return table.AddClass(str);
        }

        public static TableBuilder Condensed(this TableBuilder table)
        {
            EnsureTableClass(table);
            var str = Lookups.Lookup(TableClasses.Condensed);
            return table.AddClass(str);
        }

        public static TableBuilder Bordered(this TableBuilder table)
        {
            EnsureTableClass(table);
            var str = Lookups.Lookup(TableClasses.Bordered);
            return table.AddClass(str);
        }

        public static TableBuilder Hover(this TableBuilder table)
        {
            EnsureTableClass(table);
            var str = Lookups.Lookup(TableClasses.HoverRows);
            return table.AddClass(str);
        }

        public static TableRowBuilder Active(this TableRowBuilder rb)
        {
            rb.CategorizedCssClasses.CleanupAndAdd("el-color", Lookups.Lookup(Bootstrap.Color.Active));
            return rb;
        }
    }
}

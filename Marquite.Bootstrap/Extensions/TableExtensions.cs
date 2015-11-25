using Marquite.Core;
using Marquite.Core.Elements;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Extensions
{
    public static class TableExtensions
    {
        private static void EnsureTableClass<T>(T table) where T : TableBuilder
        {
            var tbl = Lookups.Lookup(TableClasses.Table);
            table.AddClass(tbl);
        }
        public static T Stripped<T>(this T table) where T : TableBuilder
        {
            EnsureTableClass(table);
            var str = Lookups.Lookup(TableClasses.Striped);
            return table.AddClass(str);
        }

        public static T Condensed<T>(this T table) where T : TableBuilder
        {
            EnsureTableClass(table);
            var str = Lookups.Lookup(TableClasses.Condensed);
            return table.AddClass(str);
        }

        public static T Bordered<T>(this T table) where T : TableBuilder
        {
            EnsureTableClass(table);
            var str = Lookups.Lookup(TableClasses.Bordered);
            return table.AddClass(str);
        }

        public static T Hover<T>(this T table) where T : TableBuilder
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

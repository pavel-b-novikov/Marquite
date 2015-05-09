using Marquite.Core.ElementBuilders;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Extensions
{
    public static class TableExtensions
    {
        public static TableBuilder Stripped(this TableBuilder table,bool set = true)
        {
            var str = Lookups.Lookup(TableClasses.Striped);
            if (!set)
            {
                return table.RemoveClass(str);
            }
            return table.AddClass(str);
        }

        public static TableBuilder Condensed(this TableBuilder table, bool set = true)
        {
            var str = Lookups.Lookup(TableClasses.Condensed);
            if (!set)
            {
                return table.RemoveClass(str);
            }
            return table.AddClass(str);
        }

        public static TableBuilder Bordered(this TableBuilder table, bool set = true)
        {
            var str = Lookups.Lookup(TableClasses.Bordered);
            if (!set)
            {
                return table.RemoveClass(str);
            }
            return table.AddClass(str);
        }

        public static TableBuilder Hover(this TableBuilder table, bool set = true)
        {
            var str = Lookups.Lookup(TableClasses.HoverRows);
            if (!set)
            {
                return table.RemoveClass(str);
            }
            return table.AddClass(str);
        }

        public static TableRowBuilder Active(this TableRowBuilder rb)
        {
            rb.TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Bootstrap.Color.Active));
            return rb;
        }
    }
}

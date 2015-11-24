using System;
using Marquite.Bootstrap.Elements;
using Marquite.Core;

namespace Marquite.Bootstrap.Extensions
{
    public static class ColumnGridBuilderExtensions
    {
        public static T MdWidth<T>(this T b, int width) where T : ColumnGridBuilder
        {
            if (width <= 0 || width > 12) throw new ArgumentException(Messages.Error_InvalidWidth, "width");
            b.ReplaceClass("col-md-", "col-md-" + width);
            return b;
        }

        public static T XsWidth<T>(this T b, int width) where T : ColumnGridBuilder
        {
            if (width <= 0 || width > 12) throw new ArgumentException(Messages.Error_InvalidWidth, "width");
            b.ReplaceClass("col-xs-", "col-xs-" + width);
            return b;
        }

        public static T SmWidth<T>(this T b, int width) where T : ColumnGridBuilder
        {
            if (width <= 0 || width > 12) throw new ArgumentException(Messages.Error_InvalidWidth, "width");
            b.ReplaceClass("col-sm-", "col-sm-" + width);
            return b;
        }

        public static T LgWidth<T>(this T b, int width) where T : ColumnGridBuilder
        {
            if (width <= 0 || width > 12) throw new ArgumentException(Messages.Error_InvalidWidth, "width");
            b.ReplaceClass("col-lg-", "col-lg-" + width);
            return b;
        }

        public static T MdOffset<T>(this T b, int Offset) where T : ColumnGridBuilder
        {
            if (Offset <= 0 || Offset > 12) throw new ArgumentException(Messages.Error_InvalidOffset, "Offset");
            b.ReplaceClass("col-md-", "col-md-" + Offset);
            return b;
        }

        public static T XsOffset<T>(this T b, int Offset) where T : ColumnGridBuilder
        {
            if (Offset <= 0 || Offset > 12) throw new ArgumentException(Messages.Error_InvalidOffset, "Offset");
            b.ReplaceClass("col-xs-", "col-xs-" + Offset);
            return b;
        }

        public static T SmOffset<T>(this T b, int Offset) where T : ColumnGridBuilder
        {
            if (Offset <= 0 || Offset > 12) throw new ArgumentException(Messages.Error_InvalidOffset, "Offset");
            b.ReplaceClass("col-sm-", "col-sm-" + Offset);
            return b;
        }

        public static T LgOffset<T>(this T b, int Offset) where T : ColumnGridBuilder
        {
            if (Offset <= 0 || Offset > 12) throw new ArgumentException(Messages.Error_InvalidOffset, "Offset");
            b.ReplaceClass("col-lg-", "col-lg-" + Offset);
            return b;
        }
    }
}
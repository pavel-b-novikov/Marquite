using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Bootstrap.Elements;
using Marquite.Core;
using Marquite.Core.ElementBuilders;

namespace Marquite.Bootstrap
{
    public static class Lookups
    {

        public static string Lookup(Background value)
        {
            var tVal = typeof(Background);
            return ClassLookup.Cache[tVal][(int)value];
        }

        public static string Lookup(BootstrapPull value)
        {
            var tVal = typeof(BootstrapPull);
            return ClassLookup.Cache[tVal][(int)value];
        }

        public static string Lookup(Hiding value)
        {
            var tVal = typeof(Hiding);
            return ClassLookup.Cache[tVal][(int)value];
        }

        public static string Lookup(TextColor value)
        {
            var tVal = typeof(TextColor);
            return ClassLookup.Cache[tVal][(int)value];
        }

        public static string Lookup(Device value)
        {
            var tVal = typeof(Device);
            return ClassLookup.Cache[tVal][(int)value];
        }

        public static string Lookup(Display value)
        {
            var tVal = typeof(Display);
            return ClassLookup.Cache[tVal][(int)value];
        }

        public static string Lookup(TextCasing value)
        {
            var tVal = typeof(TextCasing);
            return ClassLookup.Cache[tVal][(int)value];
        }
        public static string Lookup(ListStyles value)
        {
            var tVal = typeof(ListStyles);
            return ClassLookup.Cache[tVal][(int)value];
        }

        public static string Lookup(TableClasses value)
        {
            var tVal = typeof(TableClasses);
            return ClassLookup.Cache[tVal][(int)value];
        }

        public static string Lookup(Color value)
        {
            var tVal = typeof(Color);
            return ClassLookup.Cache[tVal][(int)value];
        }

        public static string Lookup(ButtonColor value)
        {
            var tVal = typeof(ButtonColor);
            return ClassLookup.Cache[tVal][(int)value];
        }
        public static string Lookup(ButtonSize value)
        {
            var tVal = typeof(ButtonSize);
            return ClassLookup.Cache[tVal][(int)value];
        }
        public static string Lookup(GlyphIcon value)
        {
            var tVal = typeof(GlyphIcon);
            return ClassLookup.Cache[tVal][(int)value];
        }
        public static string Lookup(TextAlign value)
        {
            var tVal = typeof(TextAlign);
            return ClassLookup.Cache[tVal][(int)value];
        }
        public static string Lookup(ImageStyle value)
        {
            var tVal = typeof(ImageStyle);
            return ClassLookup.Cache[tVal][(int)value];
        }
        public static string Lookup(InputType value)
        {
            var tVal = typeof(InputType);
            return ClassLookup.Cache[tVal][(int)value];
        }
        public static string Lookup(TooltipPlacement value)
        {
            var tVal = typeof(TooltipPlacement);
            return ClassLookup.Cache[tVal][(int)value];
        }
        public static string Lookup(FormgroupState value)
        {
            var tVal = typeof(FormgroupState);
            return ClassLookup.Cache[tVal][(int)value];
        }

        public static string Lookup(NavbarFix value)
        {
            var tVal = typeof(NavbarFix);
            return ClassLookup.Cache[tVal][(int)value];
        }

        public static string Lookup(NavbarPlacement value)
        {
            var tVal = typeof(NavbarPlacement);
            return ClassLookup.Cache[tVal][(int)value];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.ElementBuilders;

namespace Marquite.Core
{
    public static class Lookups
    {
        public static string Lookup(Css value)
        {
            var tVal = typeof(Css);
            return ClassLookup.Cache[tVal][(int)value];
        }
        public static string Lookup(TargetWindowType value)
        {
            var tVal = typeof(TargetWindowType);
            return ClassLookup.Cache[tVal][(int)value];
        }
        public static string Lookup(TextAreaWrap value)
        {
            var tVal = typeof(TextAreaWrap);
            return ClassLookup.Cache[tVal][(int)value];
        }
        public static string Lookup(FormEnctype value)
        {
            var tVal = typeof(FormEnctype);
            return ClassLookup.Cache[tVal][(int)value];
        }
        public static string Lookup(InputType value)
        {
            var tVal = typeof(InputType);
            return ClassLookup.Cache[tVal][(int)value];
        }
    }
}

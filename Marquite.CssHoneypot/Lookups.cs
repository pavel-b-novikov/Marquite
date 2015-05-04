using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core;
using Marquite.CssHoneypot.Css.Values;

namespace Marquite.CssHoneypot
{
    public static class Lookups
    {
        public static string Lookup(SizzlePseudo value)
        {
            var tVal = typeof(SizzlePseudo);
            return ClassLookup.Cache[tVal][(int)value];
        }

        public static string Lookup(PseudoClass value)
        {
            var tVal = typeof(PseudoClass);
            return ClassLookup.Cache[tVal][(int)value];
        }
        public static string Lookup(LengthUnit value)
        {
            var tVal = typeof(LengthUnit);
            return ClassLookup.Cache[tVal][(int)value];
        }
    }
}

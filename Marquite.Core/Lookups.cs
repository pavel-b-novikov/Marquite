using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core
{
    public static class Lookups
    {
        public static string Lookup(Css value)
        {
            var tVal = typeof(Css);
            return ClassLookup.Cache[tVal][(int)value];
        }
    }
}

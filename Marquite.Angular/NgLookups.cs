using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core;

namespace Marquite.Angular
{
    public static class NgLookups
    {
        public static string Lookup(NgEvent value)
        {
            var tVal = typeof(NgEvent);
            return ClassLookup.Cache[tVal][(int)value];
        }
    }
}

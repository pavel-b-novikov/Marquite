using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.CssHoneypot
{
    public class CssVersionAttribute : Attribute
    {
        public int CssVersion { get; set; }

        public CssVersionAttribute(int cssVersion)
        {
            CssVersion = cssVersion;
        }

        public CssVersionAttribute()
        {
        }
    }
}

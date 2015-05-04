using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.CssHoneypot
{
    public interface IEndOfBuilder
    {
        /// <summary>
        /// Returns accumulated selector string
        /// </summary>
        /// <returns></returns>
        string Build();
    }
}

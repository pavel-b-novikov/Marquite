using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core.Ajax
{
    public enum InsertionMode
    {
        /// <summary>
        /// Replace the contents of the element.
        /// </summary>
        Replace = 0,

        /// <summary>
        /// Insert before the element.
        /// </summary>
        InsertBefore = 1,

        /// <summary>
        /// Insert after the element.
        /// </summary>
        InsertAfter = 2,

        /// <summary>
        /// Replace the entire element.
        /// </summary>
        ReplaceWith = 3
    }
}

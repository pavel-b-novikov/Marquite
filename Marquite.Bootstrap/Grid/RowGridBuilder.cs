using System.Collections.Generic;
using System.IO;
using System.Web;
using Marquite.Core;

namespace Marquite.Bootstrap.Grid
{
    public class RowGridBuilder : BootstrapBasicBuilder<RowGridBuilder>
    {
        public RowGridBuilder(Core.Marquite m) : base(m,"div")
        {
            AddClass("row");
        }
    }
}

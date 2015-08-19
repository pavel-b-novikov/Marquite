using System.Collections.Generic;
using System.IO;
using System.Web;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Grid
{
    public class RowGridBuilder : ElementHtmlBuilder<RowGridBuilder>
    {
        public RowGridBuilder(Core.IMarquite m) : base(m,"div")
        {
            AddClass("row");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Elements
{
    public class ButtonGroup : ElementHtmlBuilder
    {
        public ButtonGroup(IMarquite marquite) : base(marquite, "div")
        {
            this.AddClass("btn-group").Attr("role", "group");
        }
    }

    [LookupEnum]
    public enum ButtonGroupSize
    {
        [LookupString("btn-group-xs")]
        XtraSmall,
        [LookupString("btn-group-xs")]
        Small,
        [LookupString("btn-group-md")]
        Normal,
        [LookupString("btn-group-lg")]
        Large
    }
}

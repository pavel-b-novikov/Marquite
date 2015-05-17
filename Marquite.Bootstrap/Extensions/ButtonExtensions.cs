using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Bootstrap.Elements;
using Marquite.Core.ElementBuilders;

namespace Marquite.Bootstrap.Extensions
{
    public static class ButtonExtensions
    {
        public static BootstrapButtonBuilder Button(this BootstrapPlugin b, string text = null)
        {
            return new BootstrapButtonBuilder(b.Marquite, "button").Content(text);
        }

        public static BootstrapButtonBuilder InputButton(this BootstrapPlugin b, string text = null)
        {
            return new BootstrapButtonBuilder(b.Marquite, "input").Attr("type", "button").Content(text);
        }

        public static BootstrapButtonBuilder SubmitButton(this BootstrapPlugin b, string text = null)
        {
            return new BootstrapButtonBuilder(b.Marquite, "input").Attr("type", "submit").Content(text);
        }

        public static BootstrapButtonBuilder LinkButton(this BootstrapPlugin b, string text = null)
        {
            return new BootstrapButtonBuilder(b.Marquite, "a").Content(text);
        }
    }
}

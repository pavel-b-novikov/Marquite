using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Bootstrap.Elements;
using Marquite.Bootstrap.Grid;
using Marquite.Core.ElementBuilders;

namespace Marquite.Bootstrap.Extensions
{
    public static class ElementsExtensions
    {
        public static ButtonBuilder Button(this Core.Marquite b, string text = null)
        {
            return new ButtonBuilder(b, "button").Content(text);
        }

        public static ButtonBuilder InputButton(this Core.Marquite b, string text = null)
        {
            return new ButtonBuilder(b, "input").Attr("type", "button").Content(text);
        }

        public static ButtonBuilder SubmitButton(this Core.Marquite b, string text = null)
        {
            return new ButtonBuilder(b, "input").Attr("type", "submit").Content(text);
        }

        public static ButtonBuilder LinkButton(this Core.Marquite b, string text = null)
        {
            return new ButtonBuilder(b, "a").Content(text);
        }

        

    }
}

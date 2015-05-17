using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.ElementBuilders;

namespace Marquite.Core.Html
{
    public static class ButtonExtensions
    {
        public static ButtonBuilder Button(this Marquite b, string text = null)
        {
            return new ButtonBuilder(b, "button").Content(text);
        }

        public static ButtonBuilder InputButton(this Marquite b, string text = null)
        {
            return new ButtonBuilder(b, "input").Attr("type", "button").Content(text);
        }

        public static ButtonBuilder SubmitButton(this Marquite b, string text = null)
        {
            return new ButtonBuilder(b, "input").Attr("type", "submit").Content(text);
        }
    }
}

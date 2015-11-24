using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.Elements;

namespace Marquite.Core.Html
{
    public static class ButtonExtensions
    {
        public static ButtonBuilder Button(this IMarquite b, string text = null)
        {
            return new ButtonBuilder(b, "button").Content(text);
        }

        public static ButtonBuilder InputButton(this IMarquite b, string text = null)
        {
            return new ButtonBuilder(b, "input").Attr("type", "button").Content(text);
        }

        public static ButtonBuilder SubmitInputButton(this IMarquite b, string text = null)
        {
            return new ButtonBuilder(b, "input").Attr("type", "submit").Content(text);
        }

        public static ButtonBuilder SubmitButton(this IMarquite b, string text = null)
        {
            return new ButtonBuilder(b, "button").Attr("type", "submit").Content(text);
        }
    }
}

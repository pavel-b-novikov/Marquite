using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marquite.Bootstrap;
using Marquite.Bootstrap.Elements;
using Marquite.Bootstrap.Extensions;
using Marquite.Bootstrap.Lists;
using Marquite.Core;

namespace Marquite.Test
{
    public static class Extensions
    {
        public static MvcHtmlString MyCoolButton(this HtmlHelper h,bool condition)
        {
            return
                h.Bootstrap()
                    .Button()
                    .When(condition, c => c.AppendText("Больше двух"))
                    .When(!condition, c => c.AppendText("Меньше двух"))
                    .Large()
                    .Danger()
                    .LeadIcon(GlyphIcon.Bell).Render();

        }

        public static ButtonBuilder BigRedButton(this HtmlHelper h,ButtonBuilder b)
        {
            return
                    b
                    .Large()
                    .Danger()
                    .LeadIcon(GlyphIcon.Bell);

        }
    }
}
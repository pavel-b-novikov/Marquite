using System.Web.Mvc;
using Marquite.Bootstrap;
using Marquite.Bootstrap.Elements;
using Marquite.Bootstrap.Extensions;
using Marquite.Core;
using Marquite.Core.Html;

namespace Marquite.Test
{
    public static class Extensions
    {
        public static MvcHtmlString MyCoolButton(this HtmlHelper h,bool condition)
        {
            return
                h.Bs()
                    .Button()
                    .When(condition, c => ButtonBuilderExtensions.AppendButtonText(c, "Больше двух"))
                    .When(!condition, c => ButtonBuilderExtensions.AppendButtonText(c, "Меньше двух"))
                    .Large()
                    .Danger()
                    .LeadIcon(GlyphIcon.Bell).Render();

        }

        public static BootstrapButtonBuilder BigRedButton(this HtmlHelper h, BootstrapButtonBuilder b)
        {
            return
                    b
                    .Large()
                    .Danger()
                    .LeadIcon(GlyphIcon.Bell);

        }
    }
}
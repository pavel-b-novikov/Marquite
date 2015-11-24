using Marquite.Bootstrap.Elements;
using Marquite.Core;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Extensions
{
    public static class DropdownBuilderExtensions
    {
        public static T Dropup<T>(this T b) where T:DropdownBuilder
        {
            b.RemoveClass("dropdown");
            b.AddClass("dropup");
            return b;
        }

        public static T TriggeringElement<T>(this T b, IRenderingClient element) where T : DropdownBuilder
        {
            b._triggeringElement = element.Detached();
            return b;
        }

        public static T Menu<T>(this T b, DropdownMenuBuilder menu) where T : DropdownBuilder
        {
            b._menu = menu.Detached();
            return b;
        }
    }
}
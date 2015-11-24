using Marquite.Bootstrap.Elements;
using Marquite.Core;

namespace Marquite.Bootstrap.Extensions
{
    public static class BootstrapCheckableExtensions
    {
        public static T Inline<T>(this T b) where T:BootstrapCheckableBuilder
        {
            return b.AddClass("inline");
        }
    }
}
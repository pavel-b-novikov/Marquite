using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Bootstrap.Elements;
using Marquite.Core;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Extensions
{
    public static class ButtonGroupBuilderExtensions
    {
        public static T Vertical<T>(this T b) where T : ButtonGroup
        {
            b.ReplaceClass("btn-group","btn-group-vertical");
            return b;
        }

        public static T Size<T>(this T b,ButtonGroupSize size = ButtonGroupSize.Normal) where T : ButtonGroup
        {
            if (size == ButtonGroupSize.Normal) b.CategorizedCssClasses.CleanupCategory("size");
            else
            {
                b.CategorizedCssClasses.CleanupAndAdd("size",Lookups.Lookup(size));
            }
            return b;
        }

        
    }
}

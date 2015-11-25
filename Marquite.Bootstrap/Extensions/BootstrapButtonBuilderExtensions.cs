using System;
using Marquite.Bootstrap.Elements;
using Marquite.Core;

namespace Marquite.Bootstrap.Extensions
{
    public static class BootstrapButtonBuilderExtensions
    {
        /// <summary>
        /// Create block level buttons—those that span the full width of a parent
        /// </summary>
        /// <returns>Chain</returns>
        public static T Block<T>(this T b) where T : BootstrapButtonBuilder 
        {
            b.AddClass("btn-block");
            return b;
        }

        public static T Active<T>(this T b) where T : BootstrapButtonBuilder 
        {
            b.AddClass("active");
            return b;
        }

        public static T Diabled<T>(this T b) where T : BootstrapButtonBuilder 
        {
            b.AddClass("disabled");
            return b;
        }

        #region Color
        public static T Color<T>(this T b,ButtonColor color) where T : BootstrapButtonBuilder 
        {
            b.CategorizedCssClasses.CleanupAndAdd("color", Lookups.Lookup(color));
            return b;
        }

        public static BootstrapButtonBuilder Danger(this BootstrapButtonBuilder b)
        {
            return Color(b,ButtonColor.Danger);
        }

        public static BootstrapButtonBuilder Info(this BootstrapButtonBuilder b)
        {
            return Color(b,ButtonColor.Info);
        }

        public static BootstrapButtonBuilder Primary(this BootstrapButtonBuilder b)
        {
            return Color(b,ButtonColor.Primary);
        }

        public static BootstrapButtonBuilder Success(this BootstrapButtonBuilder b)
        {
            return Color(b,ButtonColor.Success);
        }

        public static BootstrapButtonBuilder Warning(this BootstrapButtonBuilder b)
        {
            return Color(b,ButtonColor.Warning);
        }

        #endregion

        #region Size

        /// <summary>
        /// Fancy larger or smaller buttons? Use ButtonSize enum
        /// </summary>
        /// <param name="size">Button size</param>
        /// <returns>Chain</returns>
        public static T Size<T>(this T b,ButtonSize size) where T : BootstrapButtonBuilder 
        {
            b.CategorizedCssClasses.CleanupAndAdd("btnsize", Lookups.Lookup(size));
            return b;
        }

        /// <summary>
        /// Extra-small button
        /// </summary>
        /// <returns></returns>
        public static T XtraSmall<T>(this T b) where T : BootstrapButtonBuilder 
        {
            return Size(b,ButtonSize.XtraSmall);
        }
        public static T Small<T>(this T b) where T : BootstrapButtonBuilder 
        {
            return Size(b, ButtonSize.Small);
        }
        public static T Large<T>(this T b) where T : BootstrapButtonBuilder 
        {
            return Size(b, ButtonSize.Large);
        }
        #endregion
    }
}
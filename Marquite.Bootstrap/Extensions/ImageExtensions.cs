using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.ElementBuilders;

namespace Marquite.Bootstrap.Extensions
{
    public static class ImageExtensions
    {
        public static ImageBuilder Style(this ImageBuilder img,ImageStyle style)
        {
            return img.AddClass(Lookups.Lookup(style));
        }

        public static ImageBuilder Rounded(this ImageBuilder img)
        {
            return img.Style(ImageStyle.Rounded);
        }

        public static ImageBuilder Circle(this ImageBuilder img)
        {
            return img.Style(ImageStyle.Circle);
        }

        public static ImageBuilder Thumbnail(this ImageBuilder img)
        {
            return img.Style(ImageStyle.Thumbnail);
        }
    }
}

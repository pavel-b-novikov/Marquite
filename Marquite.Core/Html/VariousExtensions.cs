﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.ElementBuilders;

namespace Marquite.Core.Html
{
    public static class VariousExtensions
    {
        public static ImageBuilder Image(this Core.IMarquite b, string src = null, string alternativeText = null)
        {
            return new ImageBuilder(b, src, alternativeText);
        }

        public static LinkBuilder Link(this Core.IMarquite b, string innerHtml = null, string href = null)
        {
            LinkBuilder lb = new LinkBuilder(b);
            if (!string.IsNullOrEmpty(innerHtml)) lb.TrailingHtml(innerHtml);
            if (!string.IsNullOrEmpty(href)) lb.Href(href);

            return lb;
        }

    }
}

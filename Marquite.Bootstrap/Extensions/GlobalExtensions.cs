using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Extensions
{
    public static class GlobalExtensions
    {
        public static BasicHtmlBuilder<T> TextLeft<T>(this BasicHtmlBuilder<T> t)
        {
            return BootstrapTextAlign(t, TextAlign.Left);
        }

        public static BasicHtmlBuilder<T> TextNowrap<T>(this BasicHtmlBuilder<T> t)
        {
            t.AddClass("text-nowrap");
            return t;
        }

        public static BasicHtmlBuilder<T> TextRight<T>(this BasicHtmlBuilder<T> t)
        {
            return BootstrapTextAlign(t, TextAlign.Right);
        }

        public static T Role<T>(this BasicHtmlBuilder<T> t, string role)
        {
            return t.Attr("role",role);
        }

        public static BasicHtmlBuilder<T> TextCenter<T>(this BasicHtmlBuilder<T> t)
        {
            return BootstrapTextAlign(t, TextAlign.Center);
        }

        public static BasicHtmlBuilder<T> BootstrapTextAlign<T>(this BasicHtmlBuilder<T> t, TextAlign align)
        {
            t.TagsCategory.CleanupAndAdd("bs-text-a",Lookups.Lookup(align));
            return t;
        }
    }
}

using System.Collections.Generic;
using System.Web.Mvc;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.Html
{
    public static class GlobalExtensions
    {
        
        public static IMarquite Marq(this HtmlHelper h)
        {
            var im = MarquiteInstanceManager.GetInstanceManager(h);
            return im.GetInstance(h);
        }

        public static IMarquite Marq<TModel>(this HtmlHelper<TModel> h)
        {
            return Marq((HtmlHelper)h);
        }

        public static SimpleHtmlBuilder ToBuilder(this IMarquite m, string tagName)
        {
            return new SimpleHtmlBuilder(m, tagName);
        }

        public static SimpleHtmlBuilder ToBuilder(this HtmlHelper h, string tagName)
        {
            return new SimpleHtmlBuilder(Marq(h), tagName);
        }

        public static SimpleHtmlBuilder ToBuilder<TModel>(this HtmlHelper<TModel> h, string tagName)
        {
            return new SimpleHtmlBuilder(Marq(h), tagName);
        }
    }
}
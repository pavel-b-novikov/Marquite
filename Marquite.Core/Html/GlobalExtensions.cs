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

        public static SimpleHtmlBuilder Marq(this IMarquite m, string tagName)
        {
            return new SimpleHtmlBuilder(m, tagName);
        }

        public static SimpleHtmlBuilder Marq<TModel>(this HtmlHelper<TModel> h, string tagName)
        {
            return new SimpleHtmlBuilder(h.Marq(), tagName);
        }
    }
}
using System.Collections.Generic;
using System.Web.Mvc;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Elements;

namespace Marquite.Core.Html
{
    public static class GlobalExtensions
    {
        
        public static IMarquite Marq(this HtmlHelper h)
        {
            var im = MarquiteInstanceManager.GetInstanceManager(h);
            return im.GetInstance(h);
        }

        public static IMarquite Marq(this AjaxHelper h)
        {
            var im = MarquiteInstanceManager.GetInstanceManager(h.ViewContext.TempData);
            return im.GetInstance((WebViewPage) h.ViewDataContainer,h.ViewContext,h.ViewData);
        }

        public static IMarquite Marq<TModel>(this AjaxHelper<TModel> h)
        {
            var im = MarquiteInstanceManager.GetInstanceManager(h.ViewContext.TempData);
            return im.GetInstance((WebViewPage)h.ViewDataContainer, h.ViewContext, h.ViewData);
        }

        public static IMarquite Marq<TModel>(this HtmlHelper<TModel> h)
        {
            return Marq((HtmlHelper)h);
        }

        public static SimpleHtmlBuilder Spn(this HtmlHelper h, string text)
        {
            return new SimpleHtmlBuilder(h.Marq(),"span").Content(c=>c.Append(text));
        }

        public static SimpleHtmlBuilder Marq(this IMarquite m, string tagName)
        {
            return new SimpleHtmlBuilder(m, tagName);
        }

        public static SimpleHtmlBuilder Marq<TModel>(this HtmlHelper<TModel> h, string tagName)
        {
            return new SimpleHtmlBuilder(h.Marq(), tagName);
        }

        public static FieldsetBuilder Fieldset<TModel>(this HtmlHelper<TModel> h)
        {
            return new FieldsetBuilder(h.Marq());
        }
    }
}
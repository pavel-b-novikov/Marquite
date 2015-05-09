using System.Web.Mvc;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.Html
{
    public static class GlobalExtensions
    {
        public static Marquite Marquite(this HtmlHelper h)
        {
            return Core.Marquite.Instance(h);
        }

        public static Marquite Marquite<TModel>(this HtmlHelper<TModel> h)
        {
            return Core.Marquite.Instance(h);
        }

        public static SimpleHtmlBuilder ToBuilder(this Marquite m, string tagName)
        {
            return new SimpleHtmlBuilder(m, tagName);
        }

        public static SimpleHtmlBuilder ToBuilder(this HtmlHelper h, string tagName)
        {
            return new SimpleHtmlBuilder(Core.Marquite.Instance(h), tagName);
        }

        public static SimpleHtmlBuilder ToBuilder<TModel>(this HtmlHelper<TModel> h, string tagName)
        {
            return new SimpleHtmlBuilder(Core.Marquite.Instance(h), tagName);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Marquite.Core
{
    public static class WebExtensions
    {
        public static Marquite Marquitte(this HtmlHelper h, string tagName)
        {
            return Marquite.Instance(h);
        }

        public static Marquite Marquitte<TModel>(this HtmlHelper<TModel> h, string tagName)
        {
            return Marquite.Instance(h);
        }

        public static SimpleHtmlBuilder ToBuilder(this Marquite m, string tagName)
        {
            return new SimpleHtmlBuilder(m,tagName);
        }

        public static SimpleHtmlBuilder ToBuilder(this HtmlHelper h, string tagName)
        {
            return new SimpleHtmlBuilder(Marquite.Instance(h), tagName);
        }

        public static SimpleHtmlBuilder ToBuilder<TModel>(this HtmlHelper<TModel> h, string tagName)
        {
            return new SimpleHtmlBuilder(Marquite.Instance(h), tagName);
        }


    }
}

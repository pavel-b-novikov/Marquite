using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Marquite.Bootstrap.Extensions
{
    public static class HtmlExtensions
    {
        public static Core.Marquite Bootstrap(this HtmlHelper h)
        {
            return Core.Marquite.Instance(h);
        }

        public static Core.Marquite Bootstrap<TModel>(this HtmlHelper<TModel> h)
        {
            return Core.Marquite.Instance(h);
        }
    }

}

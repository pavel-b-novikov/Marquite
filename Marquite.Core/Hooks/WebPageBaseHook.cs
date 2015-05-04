using System;
using System.IO;
using System.Text;
using System.Web.WebPages;

namespace Marquite.Core.Hooks
{
    public class HookedStringWriter : StringWriter
    {
        public HookedStringWriter(StringBuilder sb)
            : base(sb)
        {
        }

        public HookedStringWriter(StringBuilder sb, IFormatProvider formatProvider)
            : base(sb, formatProvider)
        {
        }

        public HookedStringWriter(IFormatProvider formatProvider)
            : base(formatProvider)
        {
        }

        public HookedStringWriter()
        {
        }
    }

    public abstract class WebViewPageBaseHook<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        public override void Write(object value)
        {
            if (ViewContext.Writer.GetType() == typeof(HookedStringWriter))
            {
                ViewContext.Writer.Write(value);
            }
            else
            {
                base.Write(value);
            }

        }

        public override void WriteLiteral(object value)
        {
            if (ViewContext.Writer.GetType() == typeof(HookedStringWriter))
            {
                ViewContext.Writer.Write(value);
            }
            else
            {
                base.WriteLiteral(value);
            }
        }

        public override void Write(HelperResult result)
        {
            if (ViewContext.Writer.GetType() == typeof(HookedStringWriter))
            {
                ViewContext.Writer.Write(result);
            }
            else
            {
                base.Write(result);
            }
        }
    }
}

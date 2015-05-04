using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.CssHoneypot
{
    public class CssAggregator<TCssBuilder>
        where TCssBuilder:ICssBuilder,new()
    {
        private Dictionary<ISelectorBuilder, ICssBuilder> _selectors2Css = new Dictionary<ISelectorBuilder, ICssBuilder>();

        private Dictionary<string, ICssBuilder> _stringSelectors2Css = new Dictionary<string, ICssBuilder>();

        public ICssBuilder CssFor(ISelectorBuilder selector)
        {
            if (_selectors2Css.ContainsKey(selector)) return _selectors2Css[selector];
            var c = new TCssBuilder();
            _selectors2Css[selector] = c;
            return c;
        }

        public ICssBuilder CssFor(string selector)
        {
            if (_stringSelectors2Css.ContainsKey(selector)) return _stringSelectors2Css[selector];
            var c = new TCssBuilder();
            _stringSelectors2Css[selector] = c;
            return c;
        }

        public void ProduceCss(TextWriter writer,bool indented = true)
        {
            foreach (var cssBuilder in _selectors2Css)
            {
                if (!indented)
                {
                    writer.Write("{0} {{ {1} }}", cssBuilder.Key.Build(), cssBuilder.Value.Build(false));
                }
                else
                {
                    writer.Write("{0} {1} {{",cssBuilder.Key.Build(),writer.NewLine);
                    writer.Write(cssBuilder.Value.Build());
                    writer.WriteLine("{0} }} {0}",writer.NewLine);
                }
            }

            foreach (var cssBuilder in _stringSelectors2Css)
            {
                if (!indented)
                {
                    writer.Write("{0} {{ {1} }}", cssBuilder.Key, cssBuilder.Value.Build(false));
                }
                else
                {
                    writer.Write("{0} {1} {{", cssBuilder.Key, writer.NewLine);
                    writer.Write(cssBuilder.Value.Build());
                    writer.WriteLine("{0} }} {0}", writer.NewLine);
                }
            }
        }
    }
}

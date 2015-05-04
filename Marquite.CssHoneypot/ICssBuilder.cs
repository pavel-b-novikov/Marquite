using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.CssHoneypot
{
    public interface ICssBuilder
    {
        ICssBuilder RawCss(string property, string value,bool important = false);

        ICssBuilder When(bool condition,Func<ICssBuilder,ICssBuilder> conditionalProperties);

        string Build(bool indented = true);

        ICssBuilder Mix(Func<ICssBuilder, ICssBuilder> mixin);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Marquite.Angular
{
    public interface IAngularExpression : IHtmlString
    {
        string Build();

        List<string> Filters { get; }
    }
}

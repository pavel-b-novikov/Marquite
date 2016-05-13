using System.Collections.Generic;
using System.Web;
using Marquite.Core.Rendering;

namespace Marquite.Core.BuilderMechanics
{
    public interface IHtmlBuilder : IRenderingClient
    {
        string TagName { get; set; }
        string IdVal { get; set; }
        StringCategory CategorizedCssClasses { get; }
    }
}
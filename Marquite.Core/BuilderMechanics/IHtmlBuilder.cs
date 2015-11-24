using System.Collections.Generic;
using System.Web;
using Marquite.Core.Rendering;

namespace Marquite.Core.BuilderMechanics
{
    public interface IHtmlBuilder : IRenderingClient
    {
        HashSet<string> CssClasses { get; }
        SortedDictionary<Css, string> Style { get; }
        SortedDictionary<string, string> Attributes { get; }
        RenderingQueue RenderingQueue { get; }
        bool IsSelfClosing { get; set; }
        string TagName { get; set; }
        string IdVal { get; set; }
        StringCategory CategorizedCssClasses { get; }
    }
}
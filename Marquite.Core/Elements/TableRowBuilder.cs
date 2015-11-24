using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.Elements
{
    public class TableRowBuilder : ElementHtmlBuilder
    {
        public TableRowBuilder(IMarquite marquite) : base(marquite, "tr"){}
    }
}
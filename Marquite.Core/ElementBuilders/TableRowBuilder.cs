using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core.ElementBuilders
{
    public class TableRowBuilder : ElementHtmlBuilder<TableRowBuilder>
    {
        public TableRowBuilder(Marquite marquite) : base(marquite, "tr")
        {
        }

        public TableRowBuilder AddCell(string content)
        {
            Trail(content, "td");
            return this;
        }

        public TableRowBuilder AddCells(params string[] content)
        {
            content.ForEach(c => Trail(c, "td"));
            return this;
        }

        public TableRowBuilder AddCell(IRenderingClient content)
        {
            Trail(content, "td");
            return this;
        }

        public TableRowBuilder AddCells(params IRenderingClient[] content)
        {
            content.ForEach(c => Trail(c, "td"));
            return this;
        }
    }
}
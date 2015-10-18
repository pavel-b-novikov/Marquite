using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core.ElementBuilders
{
    public class TableRowBuilder : ElementHtmlBuilder<TableRowBuilder>
    {
        public TableRowBuilder(IMarquite marquite) : base(marquite, "tr")
        {
        }

        public TableRowBuilder AddCell(string content)
        {
            RenderingQueue.Trail(content, "td");
            return this;
        }

        public TableRowBuilder AddCells(params string[] content)
        {
            content.ForEach(c => RenderingQueue.Trail(c, "td"));
            return this;
        }

        public TableRowBuilder AddCell(IRenderingClient content)
        {
            RenderingQueue.Trail(content.Detached(), "td");
            return this;
        }

        public TableRowBuilder AddCells(params IRenderingClient[] content)
        {
            content.ForEach(c => RenderingQueue.Trail(c.Detached(), "td"));
            return this;
        }
    }
}
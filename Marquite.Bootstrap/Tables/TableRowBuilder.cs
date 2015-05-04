using Marquite.Core;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Tables
{
    public class TableRowBuilder : BootstrapBasicBuilder<TableRowBuilder>
    {
        public TableRowBuilder(Core.Marquite marquite) : base(marquite, "tr")
        {
        }

        public TableRowBuilder AddCell(string content)
        {
            Trail(content, "td");
            return this;
        }

        public TableRowBuilder AddCells(params string[] content)
        {
            content.ForEach(c=>Trail(c,"td"));
            return this;
        }


        public TableRowBuilder AddCell(IRenderingClient content)
        {
            Trail(content,"td");
            return this;
        }

        public TableRowBuilder AddCells(params IRenderingClient[] content)
        {
            content.ForEach(c => Trail(c,"td"));
            return this;
        }

        public virtual TableRowBuilder Active()
        {
            TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Bootstrap.Color.Active));
            return This;
        }
    }
}

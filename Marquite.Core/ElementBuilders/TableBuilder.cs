using System.IO;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core.ElementBuilders
{
    public class TableBuilder : ElementHtmlBuilder<TableBuilder>
    {
        private bool _renderTbody = true;

        public TableBuilder(Marquite m)
            : base(m, "table")
        {
            AddClass("table");
        }

        public TableBuilder AddHeadings(params string[] columnNames)
        {
            columnNames.ForEach(c => Trail(c, "td"));
            return this;
        }

        public TableBuilder AddHeading(string columnName)
        {
            Trail(columnName, "td");
            return this;
        }

        public TableBuilder AddHeadings(params IRenderingClient[] columnNames)
        {
            columnNames.ForEach(c => Trail(c));
            return this;
        }

        public TableBuilder AddHeading(IRenderingClient columnName)
        {
            Trail(columnName, "td");
            return this;
        }

        public TableBuilder DontRenderTbody()
        {
            _renderTbody = false;
            return this;
        }

        protected override void RenderAfterOpeningTag(TextWriter tw)
        {
            if (HasPendingItems)
            {
                tw.Write("<thead>{0}<tr>", tw.NewLine);
                RenderQueue(tw);
                tw.Write("</thead>{0}</tr>", tw.NewLine);
            }
            if (_renderTbody)
            {
                tw.WriteLine("<tbody>");
            }
        }

        protected override void RenderBeforeClosingTag(TextWriter tw)
        {
            if (_renderTbody)
            {
                tw.WriteLine("</tbody>");
            }
        }
    }
}
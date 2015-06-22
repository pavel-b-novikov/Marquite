using System.IO;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core.ElementBuilders
{
    public class TableBuilder : TableBuilderBase<TableBuilder>
    {
        public TableBuilder(Marquite m) : base(m)
        {
        }
    }
    public class TableBuilderBase<T> : ElementHtmlBuilder<T> where T : TableBuilderBase<T>
    {
        private bool _renderTbody = true;

        public TableBuilderBase(Marquite m)
            : base(m, "table")
        {
            AddClass("table");
        }

        public T AddHeadings(params string[] columnNames)
        {
            columnNames.ForEach(c => Trail(c, "td"));
            return This;
        }

        public T AddHeading(string columnName)
        {
            Trail(columnName, "td");
            return This;
        }

        public T AddHeadings(params IRenderingClient[] columnHeaderContents)
        {
            columnHeaderContents.ForEach(c => Trail(c,"td"));
            return This;
        }

        public T AddHeading(IRenderingClient columnHeaderContent)
        {
            Trail(columnHeaderContent, "td");
            return This;
        }

        public T DontRenderTbody()
        {
            _renderTbody = false;
            return This;
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
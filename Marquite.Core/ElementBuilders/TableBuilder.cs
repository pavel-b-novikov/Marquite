using System.Collections.Generic;
using System.IO;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core.ElementBuilders
{
    public class TableBuilder : TableBuilderBase<TableBuilder>
    {
        public TableBuilder(IMarquite m)
            : base(m)
        {
        }
    }
    public class TableBuilderBase<T> : ElementHtmlBuilder<T> where T : TableBuilderBase<T>
    {
        private bool _renderTbody = true;

        public TableBuilderBase(IMarquite m)
            : base(m, "table")
        {
            AddClass("table");
        }

        #region Heading 0
        public T AddHeadings(params string[] columnNames)
        {
            AddHeadings(0, columnNames);
            return This;
        }

        public T AddHeading(string columnName)
        {
            AddHeading(0, columnName);
            return This;
        }

        public T AddHeadings(params IRenderingClient[] columnHeaderContents)
        {
            AddHeadings(0, columnHeaderContents);
            return This;
        }

        public T AddHeading(IRenderingClient columnHeaderContent)
        {
            AddHeading(0, columnHeaderContent);
            return This;
        }
        #endregion

        private readonly List<RenderingQueue> _headRows = new List<RenderingQueue>();

        private RenderingQueue GetHeadRow(int row)
        {
            if (row > _headRows.Count - 1)
            {
                RenderingQueue rq = new RenderingQueue();
                _headRows.Add(rq);
                return rq;
            }
            return _headRows[row];
        }

        public T AddHeadings(int row, params string[] columnNames)
        {
            var tr = GetHeadRow(row);
            columnNames.ForEach(c => tr.Trail(c, "td"));
            return This;
        }

        public T AddHeading(int row, string columnName)
        {
            var tr = GetHeadRow(row);
            tr.Trail(columnName, "td");
            return This;
        }

        public T AddHeadings(int row, params IRenderingClient[] columnHeaderContents)
        {
            var tr = GetHeadRow(row);
            columnHeaderContents.ForEach(c => tr.Trail(c, "td"));
            return This;
        }

        public T AddHeading(int row, IRenderingClient columnHeaderContent)
        {
            var tr = GetHeadRow(row);
            tr.Trail(columnHeaderContent, "td");
            return This;
        }
        
        public T DontRenderTbody()
        {
            _renderTbody = false;
            return This;
        }

        public override void RenderAfterOpeningTag(TextWriter tw)
        {
            if (_headRows.Count > 0)
            {
                tw.Write("<thead>{0}", tw.NewLine);
                foreach (var renderingQueue in _headRows)
                {
                    tw.Write("<tr>");
                    renderingQueue.RenderQueue(tw);
                    tw.Write("</tr>");
                }
                
                tw.Write("</thead>{0}", tw.NewLine);
            }
            if (_renderTbody)
            {
                tw.WriteLine("<tbody>");
            }
        }

        public override void RenderBeforeClosingTag(TextWriter tw)
        {
            if (_renderTbody)
            {
                tw.WriteLine("</tbody>");
            }
        }
    }
}
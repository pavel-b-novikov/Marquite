using System.Collections.Generic;
using System.IO;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core.Elements
{
    public class TableBuilder : ElementHtmlBuilder
    {
        public bool RenderTbody { get;set; }

        public TableBuilder(IMarquite m)
            : base(m, "table")
        {
            RenderTbody = true;
            this.AddClass("table");
        }

        private readonly List<RenderingQueue> _headRows = new List<RenderingQueue>();

        internal RenderingQueue GetHeadRow(int row)
        {
            if (row > _headRows.Count - 1)
            {
                RenderingQueue rq = new RenderingQueue();
                _headRows.Add(rq);
                return rq;
            }
            return _headRows[row];
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
            if (RenderTbody)
            {
                tw.WriteLine("<tbody>");
            }
        }

        public override void RenderBeforeClosingTag(TextWriter tw)
        {
            if (RenderTbody)
            {
                tw.WriteLine("</tbody>");
            }
        }
    }
}
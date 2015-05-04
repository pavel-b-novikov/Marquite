using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Marquite.Core;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Tables
{
    public class TableBuilder : BootstrapBasicBuilder<TableBuilder>
    {
        public TableBuilder(Core.Marquite m)
            : base(m, "table")
        {
            AddClass("table");
        }

        public TableBuilder Stripped(bool set = true)
        {
            var str = Lookups.Lookup(TableClasses.Striped);
            if (!set)
            {
                return RemoveClass(str);
            }
            return AddClass(str);
        }

        public TableBuilder Condensed(bool set = true)
        {
            var str = Lookups.Lookup(TableClasses.Condensed);
            if (!set)
            {
                return RemoveClass(str);
            }
            return AddClass(str);
        }

        public TableBuilder Bordered(bool set = true)
        {
            var str = Lookups.Lookup(TableClasses.Bordered);
            if (!set)
            {
                return RemoveClass(str);
            }
            return AddClass(str);
        }

        public TableBuilder Hover(bool set = true)
        {
            var str = Lookups.Lookup(TableClasses.HoverRows);
            if (!set)
            {
                return RemoveClass(str);
            }
            return AddClass(str);
        }

        public TableBuilder AddHeadings(params string[] columnNames)
        {
            columnNames.ForEach(c => Trail(c, "td"));
            return this;
        }

        public TableBuilder AddHeading(string columnName)
        {
            Trail(columnName,"td");
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

        private bool _renderTbody = true;
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

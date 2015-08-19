using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap
{
    public class BlockQuoteBuilder : ElementHtmlBuilder<BlockQuoteBuilder>
    {

        public BlockQuoteBuilder(Core.IMarquite m)
            : base(m,"blockquote")
        {

        }

        private string _blockQuoteText;

        public BlockQuoteBuilder(Core.IMarquite m,string blockQuoteText)
            : base(m,"blockquote")
        {
            _blockQuoteText = blockQuoteText;
        }

        public BlockQuoteBuilder Text(string text)
        {
            _blockQuoteText = text;
            return This;
        }

        public BlockQuoteBuilder Reverse()
        {
            AddClass("blockquote-reverse");
            return This;
        }

        public BlockQuoteBuilder UnReverse()
        {
            RemoveClass("blockquote-reverse");
            return This;
        }
    }
}

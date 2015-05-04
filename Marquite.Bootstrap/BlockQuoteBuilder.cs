using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Marquite.Bootstrap
{
    public class BlockQuoteBuilder : BootstrapBasicBuilder<BlockQuoteBuilder>
    {

        public BlockQuoteBuilder(Core.Marquite m)
            : base(m,"blockquote")
        {

        }

        private string _blockQuoteText;

        public BlockQuoteBuilder(Core.Marquite m,string blockQuoteText)
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

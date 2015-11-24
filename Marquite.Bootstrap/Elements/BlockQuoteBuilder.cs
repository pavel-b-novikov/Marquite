using System.IO;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Elements
{
    public class BlockQuoteBuilder : ElementHtmlBuilder
    {

        public BlockQuoteBuilder(Core.IMarquite m)
            : base(m,"blockquote")
        {

        }

        internal string _blockQuoteText;

        public BlockQuoteBuilder(Core.IMarquite m,string blockQuoteText)
            : base(m,"blockquote")
        {
            _blockQuoteText = blockQuoteText;
        }

        public override void RenderContent(TextWriter tw)
        {
            tw.WriteLine(_blockQuoteText);
            base.RenderContent(tw);
        }
    }
}

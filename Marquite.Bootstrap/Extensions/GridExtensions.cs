using Marquite.Bootstrap.Grid;

namespace Marquite.Bootstrap.Extensions
{
    public static class GridExtensions
    {
        public static ContainerGridBuilder Container(this Core.Marquite b)
        {
            return new ContainerGridBuilder(b,false);
        }

        public static ContainerGridBuilder Container(this Core.Marquite b,bool fluid)
        {
            return new ContainerGridBuilder(b, fluid);
        }

        public static RowGridBuilder Row(this Core.Marquite b)
        {
            return new RowGridBuilder(b);
        }

        public static ColumnGridBuilder Column(this Core.Marquite b, int mdWidth = 0, int xsWidth = 0, int smWidth = 0, int lgWidth = 0)
        {
            return new ColumnGridBuilder(b, mdWidth, xsWidth, smWidth, lgWidth);
        }

        public static BlockQuoteBuilder BlockQuote(this Core.Marquite b)
        {
            return new BlockQuoteBuilder(b);
        }

        public static BlockQuoteBuilder BlockQuote(this Core.Marquite b,string text)
        {
            return new BlockQuoteBuilder(b, text);
        }
    }
}

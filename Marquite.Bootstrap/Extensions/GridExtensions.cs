using Marquite.Bootstrap.Elements;

namespace Marquite.Bootstrap.Extensions
{
    public static class GridExtensions
    {
        public static ContainerGridBuilder Container(this BootstrapPlugin b)
        {
            return new ContainerGridBuilder(b.Marquite,false);
        }

        public static ContainerGridBuilder Container(this BootstrapPlugin b,bool fluid)
        {
            return new ContainerGridBuilder(b.Marquite, fluid);
        }

        public static RowGridBuilder Row(this BootstrapPlugin b)
        {
            return new RowGridBuilder(b.Marquite);
        }

        public static ColumnGridBuilder Column(this BootstrapPlugin b, int mdWidth = 0, int xsWidth = 0, int smWidth = 0, int lgWidth = 0)
        {
            return new ColumnGridBuilder(b.Marquite, mdWidth, xsWidth, smWidth, lgWidth);
        }

        public static BlockQuoteBuilder BlockQuote(this BootstrapPlugin b)
        {
            return new BlockQuoteBuilder(b.Marquite);
        }

        public static BlockQuoteBuilder BlockQuote(this BootstrapPlugin b,string text)
        {
            return new BlockQuoteBuilder(b.Marquite, text);
        }
    }
}

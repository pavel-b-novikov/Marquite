using Marquite.Core.BuilderMechanics;
using Marquite.Core.Html;

namespace Marquite.Core.Elements
{
    public class OptionBuilder : ElementHtmlBuilder, ITextable, IValuable, IDisableable, ILabelable
    {
        public OptionBuilder(IMarquite marquite) : base(marquite, "option")
        {
        }
    }

    public static class OptionBuilderExtensions
    {
        
        public static T Selected<T>(this T b) where T : OptionBuilder 
        {
            return b.SelfCloseAttr("selected");
        }
    }
}

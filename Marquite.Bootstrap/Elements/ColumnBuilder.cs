using Marquite.Bootstrap.Extensions;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Elements
{
    public class ColumnGridBuilder : ElementHtmlBuilder
    {
        
        public ColumnGridBuilder(Core.IMarquite m,int mdWidth = 0, int xsWidth = 0, int smWidth = 0,int lgWidth = 0)
            : base(m,"div")
        {
            if (mdWidth != 0) ColumnGridBuilderExtensions.MdWidth(this, mdWidth);
            if (xsWidth != 0) ColumnGridBuilderExtensions.XsWidth(this, mdWidth);
            if (smWidth != 0) ColumnGridBuilderExtensions.SmWidth(this, mdWidth);
            if (lgWidth != 0) ColumnGridBuilderExtensions.LgWidth(this, mdWidth);

        }
    }
}

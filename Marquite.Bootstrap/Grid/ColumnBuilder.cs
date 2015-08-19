using System;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Grid
{
    public class ColumnGridBuilder : ElementHtmlBuilder<ColumnGridBuilder>
    {
        
        public ColumnGridBuilder(Core.IMarquite m,int mdWidth = 0, int xsWidth = 0, int smWidth = 0,int lgWidth = 0)
            : base(m,"div")
        {
            if (mdWidth != 0) MdWidth(mdWidth);
            if (xsWidth != 0) XsWidth(mdWidth);
            if (smWidth != 0) SmWidth(mdWidth);
            if (lgWidth != 0) LgWidth(mdWidth);

        }

        public ColumnGridBuilder MdWidth(int width)
        {
            if (width <= 0 || width > 12) throw new ArgumentException(Messages.Error_InvalidWidth, "width");
            ReplaceClass("col-md-", "col-md-" + width);
            return this;
        }

        public ColumnGridBuilder XsWidth(int width)
        {
            if (width<=0||width>12) throw new ArgumentException(Messages.Error_InvalidWidth,"width");
            ReplaceClass("col-xs-", "col-xs-" + width);
            return this;
        }

        public ColumnGridBuilder SmWidth(int width)
        {
            if (width <= 0 || width > 12) throw new ArgumentException(Messages.Error_InvalidWidth, "width");
            ReplaceClass("col-sm-", "col-sm-" + width);
            return this;
        }

        public ColumnGridBuilder LgWidth(int width)
        {
            if (width <= 0 || width > 12) throw new ArgumentException(Messages.Error_InvalidWidth, "width");
            ReplaceClass("col-lg-", "col-lg-" + width);
            return this;
        }

        public ColumnGridBuilder MdOffset(int Offset)
        {
            if (Offset <= 0 || Offset > 12) throw new ArgumentException(Messages.Error_InvalidOffset, "Offset");
            ReplaceClass("col-md-", "col-md-" + Offset);
            return this;
        }

        public ColumnGridBuilder XsOffset(int Offset)
        {
            if (Offset <= 0 || Offset > 12) throw new ArgumentException(Messages.Error_InvalidOffset, "Offset");
            ReplaceClass("col-xs-", "col-xs-" + Offset);
            return this;
        }

        public ColumnGridBuilder SmOffset(int Offset)
        {
            if (Offset <= 0 || Offset > 12) throw new ArgumentException(Messages.Error_InvalidOffset, "Offset");
            ReplaceClass("col-sm-", "col-sm-" + Offset);
            return this;
        }

        public ColumnGridBuilder LgOffset(int Offset)
        {
            if (Offset <= 0 || Offset > 12) throw new ArgumentException(Messages.Error_InvalidOffset, "Offset");
            ReplaceClass("col-lg-", "col-lg-" + Offset);
            return this;
        }


    }
}

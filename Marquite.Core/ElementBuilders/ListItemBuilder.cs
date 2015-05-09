using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.ElementBuilders
{
    public class ListItemBuilder<T> : ElementHtmlBuilder<T>
    {
        public ListItemBuilder(Marquite m) : base(m, "li")
        {
        }
    }
}
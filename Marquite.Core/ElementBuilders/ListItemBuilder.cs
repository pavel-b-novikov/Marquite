using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.ElementBuilders
{
    public class ListItemBuilder<T> : ElementHtmlBuilder<T> where T : ListItemBuilder<T>
    {
        public ListItemBuilder(Marquite m) : base(m, "li")
        {
        }
    }
}
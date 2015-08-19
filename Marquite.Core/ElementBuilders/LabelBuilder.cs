using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.ElementBuilders
{
    public class LabelBuilder : LabelBuilderBase<LabelBuilder>
    {
        public LabelBuilder(IMarquite marquite) : base(marquite)
        {
        }
    }

    public class LabelBuilderBase<T> : ElementHtmlBuilder<T> where T : LabelBuilderBase<T>
    {
        public LabelBuilderBase(IMarquite marquite)
            : base(marquite, "label")
        {
        }

        public T For(string forField)
        {
            return Attr("for", forField);
        }

        public T Text(string text)
        {
            return TrailingText(text);
        }
    }
}

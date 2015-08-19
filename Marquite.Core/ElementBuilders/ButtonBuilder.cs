using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.ElementBuilders
{
    public class ButtonBuilder : ButtonBuilderBase<ButtonBuilder>
    {
        public ButtonBuilder(IMarquite marquite, string tagName) : base(marquite, tagName)
        {
        }
    }

    public class ButtonBuilderBase<T> : ElementHtmlBuilder<T> where T : ButtonBuilderBase<T>
    {
        public ButtonBuilderBase(IMarquite marquite, string tagName)
            : base(marquite, tagName)
        {

        }

        public T Content(string text)
        {
            if (TagName == "input")
            {
                if (string.IsNullOrEmpty(text)) RemoveAttr("value");
                else Attr("value", text);
            }
            else
            {
                RenderingQueue.ClearQueue();
                RenderingQueue.Trail(text);
            }
            return This;
        }

        public T AppendText(string text)
        {
            if (string.IsNullOrEmpty(text)) return This;

            if (TagName == "input")
            {
                Attr("value", GetAttr("value") + text);
            }
            else
            {
                RenderingQueue.Trail(text);
            }
            return This;
        }

        public T Submit()
        {
            Attr("type", "submit");
            return This;
        }
    }
}

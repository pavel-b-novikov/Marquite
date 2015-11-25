using System.Collections.Generic;
using Marquite.Bootstrap.Extensions;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Elements;

namespace Marquite.Bootstrap.Elements
{
    public class FormGroupBuilder : ElementHtmlBuilder, IBootstrapped
    {
        internal struct FormLineElement
        {
            public int Width;
            public int Offset;
            public IHtmlBuilder Element;
        }

        internal readonly List<FormLineElement> _elements = new List<FormLineElement>();
        
        public FormGroupBuilder(IMarquite marquite)
            : base(marquite, "div")
        {
            this.AddClass("form-group");
            Bootstrap = marquite.ResolvePlugin<BootstrapPlugin>();
        }

        public override void PrepareForRender()
        {
            base.PrepareForRender();
            bool isFormHorizontal = Marquite.ResolvePlugin<BootstrapPlugin>().IsCurrentFormHorizontal;
            foreach (var formLineElement in _elements)
            {
                var element = formLineElement.Element;
                if (element is IInputField) element.AddClass("form-control");
                if (isFormHorizontal)
                {
                    if (element.TagName == "label")
                    {
                        SetWidth(element, formLineElement);
                        element.AddClass("control-label");
                        this.Append(element);
                    }
                    else
                    {
                        SimpleHtmlBuilder divElement = new SimpleHtmlBuilder(Marquite, "div");
                        SetWidth(divElement, formLineElement);
                        divElement.Append(formLineElement.Element);
                        this.Append(divElement);
                    }
                }
                else
                {
                    this.Append(element);
                }
            }
        }

        private void SetWidth(IHtmlBuilder element, FormLineElement metrics)
        {
            if (metrics.Width > 0) element.AllWidth(metrics.Width);
            if (metrics.Offset > 0) element.AllOffset(metrics.Offset);
        }

        public BootstrapPlugin Bootstrap { get; private set; }
    }
}

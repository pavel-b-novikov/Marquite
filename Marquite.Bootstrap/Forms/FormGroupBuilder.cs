using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Bootstrap.Extensions;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;

namespace Marquite.Bootstrap.Forms
{
    public class FormGroupBuilder : ElementHtmlBuilder<FormGroupBuilder>
    {
        private struct FormLineElement
        {
            public int Width;
            public int Offset;
            public IHtmlBuilder Element;
        }

        private readonly List<FormLineElement> _elements = new List<FormLineElement>();
        private readonly BootstrapPlugin _bs;
        public FormGroupBuilder(IMarquite marquite)
            : base(marquite, "div")
        {
            AddClass("form-group");
            _bs = marquite.ResolvePlugin<BootstrapPlugin>();
        }

        public FormGroupBuilder AddElement(IHtmlBuilder element, int width = 0, int offset = 0)
        {
            if (width < 0 || width > 12) throw new Exception("Form line element width cannot be less than 0 and more than 12");
            if (offset < 0 || offset > 11) throw new Exception("Form line element offset cannot be less than 0 and more than 11");
            _elements.Add(new FormLineElement() { Width = width, Offset = offset, Element = element.Detached() });
            return This;
        }

        public FormGroupBuilder LabelSrOnly()
        {
            if (!(_elements[0].Element is LabelBuilder)) 
                return this;
            _elements[0].Element.NonGeneric_AddClass("sr-only");
            return this;
        }

        public FormGroupBuilder AddElement(IHtmlBuilder label,IHtmlBuilder input)
        {
            int labelWidth = _bs.CurrentFormLabelWidth;
            int contentWidth = _bs.CurrentFormContentWidth;
            if (label != null)
            {
                _elements.Add(new FormLineElement() {Width = labelWidth, Offset = 0, Element = label.Detached()});
                _elements.Add(new FormLineElement() {Width = contentWidth, Offset = 0, Element = input.Detached()});
            }
            else
            {
                _elements.Add(new FormLineElement() { Width = contentWidth, Offset = labelWidth, Element = input.Detached() });
            }
            
            return This;
        }

        public override void PrepareForRender()
        {
            base.PrepareForRender();
            bool isFormHorizontal = Marquite.ResolvePlugin<BootstrapPlugin>().IsCurrentFormHorizontal;
            foreach (var formLineElement in _elements)
            {
                var element = formLineElement.Element;
                if (element is IInputField) element.NonGeneric_AddClass("form-control");
                if (isFormHorizontal)
                {
                    if (element.Tag == "label")
                    {
                        SetWidth(element, formLineElement);
                        element.NonGeneric_AddClass("control-label");
                        TrailingHtml(element);
                    }
                    else
                    {
                        SimpleHtmlBuilder divElement = new SimpleHtmlBuilder(Marquite, "div");
                        SetWidth(divElement, formLineElement);
                        divElement.TrailingHtml(formLineElement.Element);
                        TrailingHtml(divElement);
                    }
                }
                else
                {
                    TrailingHtml(element);
                }
            }
        }

        private void SetWidth(IHtmlBuilder element, FormLineElement metrics)
        {
            if (metrics.Width > 0) element.AllWidth(metrics.Width);
            if (metrics.Offset > 0) element.AllOffset(metrics.Offset);
        }
    }
}

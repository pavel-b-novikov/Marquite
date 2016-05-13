using System;
using Marquite.Bootstrap.Elements;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Elements;

namespace Marquite.Bootstrap.Extensions
{
    public static class FormGroupBuilderExtensions
    {
        public static T AddElement<T>(this T b, BasicHtmlBuilder element, int width = 0, int offset = 0) where T:FormGroupBuilder
        {
            if (width < 0 || width > 12) throw new Exception("Form line element width cannot be less than 0 and more than 12");
            if (offset < 0 || offset > 11) throw new Exception("Form line element offset cannot be less than 0 and more than 11");
            b._elements.Add(new FormGroupBuilder.FormLineElement() { Width = width, Offset = offset, Element = element.Detached() });
            return b;
        }

        public static T LabelSrOnly<T>(this T b) where T : FormGroupBuilder
        {
            if (!(b._elements[0].Element is LabelBuilder))
                return b;
            b._elements[0].Element.AddClass("sr-only");
            return b;
        }

        public static T AddElement<T>(this T b, BasicHtmlBuilder label, BasicHtmlBuilder input) where T : FormGroupBuilder
        {
            int labelWidth = b.Bootstrap.CurrentFormLabelWidth;
            int contentWidth = b.Bootstrap.CurrentFormContentWidth;
            if (label != null)
            {
                b._elements.Add(new FormGroupBuilder.FormLineElement() { Width = labelWidth, Offset = 0, Element = label.Detached() });
                b._elements.Add(new FormGroupBuilder.FormLineElement() { Width = contentWidth, Offset = 0, Element = input.Detached() });
            }
            else
            {
                b._elements.Add(new FormGroupBuilder.FormLineElement() { Width = contentWidth, Offset = labelWidth, Element = input.Detached() });
            }

            return b;
        }
    }
}
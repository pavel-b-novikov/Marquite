using System;
using Marquite.Bootstrap.Elements;
using Marquite.Core;
using Marquite.Core.Elements;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Extensions
{
    public static class InputGroupBuilderExtensions
    {
        public static T WithLeftAddon<T>(this T b, IRenderingClient leftContent) where T : InputGroupBuilder
        {
            b._leftText = null;
            b._leftContent = leftContent.Detached();
            return b;
        }

        public static T WithLeftButton<T>(this T b, BootstrapButtonBuilder button) where T : InputGroupBuilder
        {
            if (b._leftContent != null || b._leftText != null) throw new Exception("Addon left content already set and button cannot be added");
            b._leftButton = button.Detached();
            return b;
        }

        public static T WithRightButton<T>(this T b, BootstrapButtonBuilder button) where T : InputGroupBuilder
        {
            if (b._rightContent != null || b._rightText != null) throw new Exception("Addon right content already set and button cannot be added");
            b._rightButton = button.Detached();
            return b;
        }

        public static T WithRightAddon<T>(this T b, string rightText) where T : InputGroupBuilder
        {
            b._rightContent = null;
            b._rightText = rightText;
            return b;
        }

        public static T WithRightAddon<T>(this T b, IRenderingClient rightContent) where T : InputGroupBuilder
        {
            b._rightText = null;
            b._rightContent = rightContent.Detached();
            return b;
        }

        public static T WithTextField<T>(this T b, InputElementBuilder textField) where T : InputGroupBuilder
        {
            if (!textField.FieldType.IsTextual())
                throw new ArgumentException("Input group works only with textual inputs", "textField");
            b._inputElement = textField.Detached().AddClass("form-control");
            return b;
        }

    }
}
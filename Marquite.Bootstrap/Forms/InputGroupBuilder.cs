using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Bootstrap.Elements;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Forms
{
    public class InputGroupBuilder : ElementHtmlBuilder<InputGroupBuilder>
    {
        public InputGroupBuilder(Core.IMarquite marquite)
            : base(marquite, "div ")
        {
            AddClass("input-group");
        }
        
        public InputGroupBuilder(InputElementBuilder textField):this(textField.Marquite)
        {
            WithTextField(textField);
        }

        private InputElementBuilder _inputElement;

        public InputGroupBuilder WithTextField(InputElementBuilder textField)
        {
            if (!textField.FieldType.IsTextual())
                throw new ArgumentException("Input group works only with textual inputs","textField");
            _inputElement = textField;
            return this;
        }

        private string _leftText;
        private string _rightText;
        private IRenderingClient _leftContent;
        private IRenderingClient _rightContent;
        private BootstrapButtonBuilder _leftButton;
        private BootstrapButtonBuilder _rightButton;

        public InputGroupBuilder WithLeftAddon(string leftText)
        {
            _leftContent = null;
            _leftText = leftText;
            return this;
        }

        public InputGroupBuilder WithLeftAddon(IRenderingClient leftContent)
        {
            _leftText = null;
            _leftContent = leftContent;
            return this;
        }

        public InputGroupBuilder WithLeftButton(BootstrapButtonBuilder button)
        {
            if (_leftContent != null || _leftText != null) throw new Exception("Addon left content already set and button cannot be added");
            _leftButton = button;
            return this;
        }

        public InputGroupBuilder WithRightButton(BootstrapButtonBuilder button)
        {
            if (_rightContent!=null||_rightText!=null) throw new Exception("Addon right content already set and button cannot be added");
            _rightButton = button;
            return this;
        }

        public InputGroupBuilder WithRightAddon(string rightText)
        {
            _rightContent = null;
            _rightText = rightText;
            return this;
        }

        public InputGroupBuilder WithRightAddon(IRenderingClient rightContent)
        {
            _rightText = null;
            _rightContent = rightContent;
            return this;
        }

        protected override void PrepareForRender()
        {
            if (_leftText != null) RenderingQueue.Trail(_leftText, "span", wrappingTagAttrs: HtmlText.Class("input-group-addon"));
            if (_leftContent != null) RenderingQueue.Trail(_leftContent, "span", wrappingTagAttrs: HtmlText.Class("input-group-addon"));
            if (_leftButton != null) RenderingQueue.Trail(_leftButton, "span", wrappingTagAttrs: HtmlText.Class("input-group-btn"));
            RenderingQueue.Trail(_inputElement);
            if (_rightText != null) RenderingQueue.Trail(_rightText, "span", wrappingTagAttrs: HtmlText.Class("input-group-addon"));
            if (_rightContent != null) RenderingQueue.Trail(_rightContent, "span", wrappingTagAttrs: HtmlText.Class("input-group-addon"));
            if (_rightButton != null) RenderingQueue.Trail(_rightButton, "span", wrappingTagAttrs: HtmlText.Class("input-group-btn"));

            base.PrepareForRender();
        }

    }
}

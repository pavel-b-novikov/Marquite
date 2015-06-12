using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Forms
{
    public class InputGroupBuilder : ElementHtmlBuilder<InputGroupBuilder>
    {
        public InputGroupBuilder(Core.Marquite marquite)
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
            if (_leftText != null) TrailingText(_leftText);
            if (_leftContent != null) TrailingHtml(_leftContent);

            base.PrepareForRender();
        }
    }
}

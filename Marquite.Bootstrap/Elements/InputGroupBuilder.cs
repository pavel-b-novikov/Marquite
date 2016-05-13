using Marquite.Bootstrap.Extensions;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Elements;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class InputGroupBuilder : ElementHtmlBuilder
    {
        public InputGroupBuilder(IMarquite marquite)
            : base(marquite, "div")
        {
           this.AddClass("input-group");
        }
        
        public InputGroupBuilder(InputElementBuilder textField):this(textField.Marquite)
        {
            this.WithTextField(textField);
        }

        internal InputElementBuilder _inputElement;
        internal string _leftText;
        internal string _rightText;
        internal IRenderingClient _leftContent;
        internal IRenderingClient _rightContent;
        internal BootstrapButtonBuilder _leftButton;
        internal BootstrapButtonBuilder _rightButton;

        public InputGroupBuilder WithLeftAddon(string leftText)
        {
            _leftContent = null;
            _leftText = leftText;
            return this;
        }

        

        public override void PrepareForRender()
        {
            if (_leftText != null) this.Content(c=>c.Trail(_leftText, "span", wrappingTagAttrs: HtmlText.Class("input-group-addon")));
            if (_leftContent != null) this.Content(c=>c.Trail(_leftContent, "span", wrappingTagAttrs: HtmlText.Class("input-group-addon")));
            if (_leftButton != null) this.Content(c=>c.Trail(_leftButton, "span", wrappingTagAttrs: HtmlText.Class("input-group-btn")));
            this.Content(c=>c.Trail(_inputElement));
            if (_rightText != null) this.Content(c=>c.Trail(_rightText, "span", wrappingTagAttrs: HtmlText.Class("input-group-addon")));
            if (_rightContent != null) this.Content(c=>c.Trail(_rightContent, "span", wrappingTagAttrs: HtmlText.Class("input-group-addon")));
            if (_rightButton != null) this.Content(c=>c.Trail(_rightButton, "span", wrappingTagAttrs: HtmlText.Class("input-group-btn")));

            base.PrepareForRender();
        }

    }
}

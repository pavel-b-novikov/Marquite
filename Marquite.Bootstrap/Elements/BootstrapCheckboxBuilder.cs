using System;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class BootstrapCheckboxBuilder : BasicHtmlBuilder<BootstrapCheckboxBuilder>
    {
        public BootstrapCheckboxBuilder(Core.IMarquite marquite) : base(marquite, "div")
        {
            AddClass("checkbox");
        }


        public BootstrapCheckboxBuilder(InputElementBuilder checkbox) : this(checkbox.Marquite)
        {
            WithInput(checkbox);
        }

        private InputElementBuilder _checkboxInput;

        public BootstrapCheckboxBuilder WithInput(InputElementBuilder checkboxInput)
        {
            if (checkboxInput.FieldType!=MarquiteInputType.CheckBox)
                throw new ArgumentException("Only checkbox inputs are possible inside bootstrap checkbox","checkboxInput");
            _checkboxInput = checkboxInput.Detached();
            if (checkboxInput.IsDisabled)
            {
                Disabled();
            }
            return this;
        }

        public BootstrapCheckboxBuilder WithLabel(string label)
        {
            return TrailingText(label);
        }

        public BootstrapCheckboxBuilder WithLabel(IRenderingClient label)
        {
            return TrailingHtml(label.Detached());
        }

        public BootstrapCheckboxBuilder Disabled()
        {
            return AddClass("disabled");
        }

        public BootstrapCheckboxBuilder Inline()
        {
            return AddClass("inline");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class BootstrapCheckboxBuilder : BasicHtmlBuilder<BootstrapCheckboxBuilder>
    {
        public BootstrapCheckboxBuilder(Core.Marquite marquite) : base(marquite, "div")
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
            _checkboxInput = checkboxInput;
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
            return TrailingHtml(label);
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

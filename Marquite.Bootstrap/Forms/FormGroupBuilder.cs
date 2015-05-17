using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Forms
{
    public class FormGroupBuilder : ElementHtmlBuilder<FormGroupBuilder>
    {
        public FormGroupBuilder(Core.Marquite marquite) : base(marquite, "div")
        {
            AddClass("form-group");
        }

        private LabelBuilder _label;
        private IRenderingClient _renderedControl;
        private int _labelWidth;
        private IRenderingClient _helpBlockClient;
        private string _helpBlockString;

        public FormGroupBuilder WithLabel(LabelBuilder label)
        {
            _label = label;
            return This;
        }

        public FormGroupBuilder WithControl(IRenderingClient element)
        {
            _renderedControl = element;
            if (_label!= null && element is IInputField)
            {
                IInputField elem = (IInputField) element;
                _label.For(elem.FieldId);
            }
            return This;
        }

        public FormGroupBuilder HelpBlock(string helpBlock)
        {
            _helpBlockClient = null;
            _helpBlockString = helpBlock;
        }

        public FormGroupBuilder HelpBlock(IRenderingClient helpBlock)
        {
            _helpBlockClient = helpBlock;
            _helpBlockString = null;
        }

        //todo add .control-label to label before rendering
    }
}

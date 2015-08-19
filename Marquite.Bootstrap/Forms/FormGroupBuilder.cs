﻿using Marquite.Bootstrap.Extensions;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;

namespace Marquite.Bootstrap.Forms
{
    public class FormGroupBuilder : ElementHtmlBuilder<FormGroupBuilder>
    {
        private readonly BootstrapPlugin _bs;
        public FormGroupBuilder(Core.IMarquite marquite)
            : base(marquite, "div")
        {
            AddClass("form-group");
            _bs = marquite.ResolvePlugin<BootstrapPlugin>();
            _labelWidth = _bs.CurrentFormLabelWidth;
            _contentWidth = _bs.CurrentFormContentWidth;
        }

        private LabelBuilder _label;
        private IHtmlBuilder _renderedControl;
        private int _labelWidth;
        private int _contentWidth;

        private IHtmlBuilder _helpBlockClient;
        private string _helpBlockString;

        public FormGroupBuilder WithLabel(LabelBuilder label)
        {
            _label = label;
            return This;
        }

        public FormGroupBuilder WithLabel(string label, bool srOnly = false)
        {
            _label = new LabelBuilder(Marquite).TrailingText(label).When(srOnly, c => c.SrOnly());
            return This;
        }

        public FormGroupBuilder WithControl(IHtmlBuilder element)
        {
            _renderedControl = element;
            var elem = element as IInputField;
            if (_label != null && elem != null)
            {
                _label.For(elem.FieldId);
            }
            if (element is IInputField)
            {
                if (elem.FieldType != MarquiteInputType.CheckBox)
                {
                    element.NonGeneric_AddClass("form-control");
                }
            }
            else
            {
                if (element.Tag == "p" || element.Tag == "span")
                {
                    element.NonGeneric_AddClass("form-control-static");
                }
            }
            return This;
        }

        public FormGroupBuilder HelpBlock(string helpBlock)
        {
            _helpBlockClient = null;
            _helpBlockString = helpBlock;
            return this;
        }

        public FormGroupBuilder HelpBlock(IHtmlBuilder helpBlock)
        {
            _helpBlockClient = helpBlock;
            _helpBlockString = null;
            return this;
        }

        public FormGroupBuilder LabelWidth(int w)
        {
            _labelWidth = w;
            return this;
        }

        public FormGroupBuilder ContentWidth(int w)
        {
            _contentWidth = w;
            return this;
        }

        #region States
        public FormGroupBuilder State(FormgroupState state)
        {
            TagsCategory.CleanupAndAdd("frmgrp-state", Lookups.Lookup(state));
            return this;
        }

        public FormGroupBuilder Success()
        {
            return State(FormgroupState.HasSuccess);
        }

        public FormGroupBuilder Warning()
        {
            return State(FormgroupState.HasWarning);
        }

        public FormGroupBuilder Error()
        {
            return State(FormgroupState.HasError);
        }
        #endregion

        protected override void PrepareForRender()
        {
            base.PrepareForRender();
            if (_contentWidth == 0 && _labelWidth != 0) _contentWidth = 12 - _labelWidth;
            if (_label != null)
            {
                if (_bs.IsCurrentFormHorizontal)
                {
                    _label.AddClass("control-label");
                    if (_labelWidth != 0)
                    {
                        _label
                            .LgWidth(_labelWidth)
                            .SmWidth(_labelWidth)
                            .XsWidth(_labelWidth)
                            .MdWidth(_labelWidth);
                    }
                }
                RenderingQueue.Trail(_label);
            }

            SimpleHtmlBuilder divElement = new SimpleHtmlBuilder(Marquite, "div");
            if (_renderedControl != null)
            {
                if (_bs.IsCurrentFormHorizontal)
                {
                    if (_label == null)
                    {
                        if (_labelWidth != 0)
                        {
                            divElement
                                .LgOffset(_labelWidth)
                                .SmOffset(_labelWidth)
                                .XsOffset(_labelWidth)
                                .MdOffset(_labelWidth);
                        }
                    }

                    if (_contentWidth != 0)
                    {
                        divElement
                            .LgWidth(_contentWidth)
                            .SmWidth(_contentWidth)
                            .XsWidth(_contentWidth)
                            .MdWidth(_contentWidth);
                    }
                }

                var fld = _renderedControl as IInputField;
                if (fld != null && fld.FieldType == MarquiteInputType.CheckBox)
                {
                    SimpleHtmlBuilder checkboxElement = new SimpleHtmlBuilder(Marquite, "div")
                        .AddClass("checkbox")
                        .TrailingHtml(
                            new LabelBuilder(Marquite)
                                .TrailingHtml(_renderedControl)
                        );
                    divElement.TrailingHtml(checkboxElement);
                }
                else
                {
                    divElement.TrailingHtml(_renderedControl);
                }
            }
            var help = ProduceHelpBlock();
            if (help != null) divElement.TrailingHtml(help);

            RenderingQueue.Trail(divElement);
        }

        private SimpleHtmlBuilder ProduceHelpBlock()
        {
            if (_helpBlockClient != null || _helpBlockString != null)
            {
                SimpleHtmlBuilder helpBlock = new SimpleHtmlBuilder(Marquite, "span").AddClass("help-block");
                if (!string.IsNullOrEmpty(_helpBlockString))
                {
                    helpBlock.TrailingText(_helpBlockString);
                }
                else
                {
                    helpBlock.TrailingHtml(_helpBlockClient);
                }
                return helpBlock;
            }
            return null;
        }
    }
}

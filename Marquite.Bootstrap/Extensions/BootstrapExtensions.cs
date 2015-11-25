﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Bootstrap.Elements;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Elements;

namespace Marquite.Bootstrap.Extensions
{
    public static class BootstrapExtensions
    {
        public static ButtonGroup ButtonGroup(this BootstrapPlugin bs, params BootstrapButtonBuilder[] buttons)
        {
            if (buttons.Length == 0) throw new Exception("Empty button group");
            ButtonGroup bg = new ButtonGroup(bs.Marquite);
            foreach (var bootstrapButtonBuilder in buttons)
            {
                bg.Append(bootstrapButtonBuilder);
            }
            return bg;
        }

        public static ButtonGroup Dropdown(this BootstrapPlugin bs, string text, Action<DropdownBuilder> dropdownOptions, Action<BootstrapButtonBuilder> toggleButtonOptions = null, Action<SimpleHtmlBuilder> caretOptions = null)
        {
            ButtonGroup bg = new ButtonGroup(bs.Marquite);
            BootstrapButtonBuilder bbs =
                new BootstrapButtonBuilder(bs.Marquite, "button")
                .AddClass("dropdown-toggle")
                .Data("toggle", "dropdown")
                .Aria("haspopup", "true")
                .Aria("expanded", "false");

            bbs.AppendText(text);
            SimpleHtmlBuilder caret = new SimpleHtmlBuilder(bs.Marquite, "span");
            caret.AddClass("caret");
            bbs.Append(caret);

            DropdownBuilder ddb = new DropdownBuilder(bs.Marquite, "ul");
            bg.Append(bbs).Append(ddb);

            dropdownOptions.ApplyFn(ddb);
            toggleButtonOptions.ApplyFn(bbs);
            caretOptions.ApplyFn(caret);
            return bg;
        }
    }
}
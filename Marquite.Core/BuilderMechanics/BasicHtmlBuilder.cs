﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marquite.Core.Rendering;

namespace Marquite.Core.BuilderMechanics
{
    /// <summary>
    /// Warning! This class is mutable! Dont re-use its static instances!
    /// </summary>
    public class BasicHtmlBuilder : RenderingClientBase, IHtmlBuilder
    {
        #region Private fields
        private RenderingQueue _content = new RenderingQueue();
        private readonly RenderingQueue _before = new RenderingQueue();
        private readonly RenderingQueue _after = new RenderingQueue();
        private readonly IMarquite _marquite;
        private readonly HashSet<string> _cssClasses = new HashSet<string>();
        private readonly SortedDictionary<Css, string> _style = new SortedDictionary<Css, string>();
        private readonly SortedDictionary<string, string> _attributes = new SortedDictionary<string, string>(StringComparer.Ordinal);
        private readonly StringCategory _categorizedCssClasses;
        private readonly bool _isScoped;
        private readonly List<string> _freeOpening = new List<string>();
        #endregion

        internal RenderingQueue Before { get { return _before; } }

        internal RenderingQueue After { get { return _after; } }

        public BasicHtmlBuilder(IMarquite marquite, string tagName)
        {
            _marquite = marquite;
            _categorizedCssClasses = new StringCategory(_cssClasses);
            TagName = tagName;
            marquite.EventsManager.OnCreated(this);
            if (marquite.ScopeManager.HasActiveScope)
            {
                marquite.ScopeManager.CurrentScope.Append(this);
                _isScoped = true;
            }
        }

        #region IHtmlBuilder implementation

        internal SortedDictionary<string, string> Attributes { get { return _attributes; } }
        internal RenderingQueue Content { get { return _content; } }
        internal List<string> Free { get { return _freeOpening; } }
        internal bool IsSelfClosing { get; set; }
        public string TagName { get; set; }
        public string IdVal { get; set; }
        public StringCategory CategorizedCssClasses { get { return _categorizedCssClasses; } }
        internal HashSet<string> CssClasses { get { return _cssClasses; } }
        internal SortedDictionary<Css, string> Style { get { return _style; } }

        public override IMarquite Marquite
        {
            get { return _marquite; }
        }

        #endregion

        #region Rendering

        public virtual MvcHtmlString Render()
        {
            Renderer.Render(Marquite.GetTopmostWriter(), this);
            return MvcHtmlString.Empty;
        }

        public virtual MvcHtmlString Render(bool condition)
        {
            if (condition)
            {
                return Render();
            }
            return MvcHtmlString.Empty;
        }

        public virtual string Compile()
        {
            return Renderer.Render(this);
        }

        public virtual string Compile(bool condition)
        {
            if (condition)
            {
                return Compile();
            }
            return String.Empty;
        }

        public virtual ITagScope Open(bool pullExistingContentAtTop = false)
        {
            if (_isScoped)
            {
                var ts = new TagScope(_marquite);
                _content.CopyTo(ts.Scope.RenderingQueue);
                _content = ts.Scope.RenderingQueue;
                return ts;
            }
            PrepareForRender();
            RenderingTagScope its = new RenderingTagScope(this, pullExistingContentAtTop);
            its.Render();
            return its;
        }

        #endregion

        #region Rendering pipeline
        public override void RenderOpeningTag(TextWriter tw)
        {
            if (string.IsNullOrEmpty(TagName)) return;

            var css = _cssClasses.ToArray();

            tw.ChainWrite('<').ChainWrite(TagName).ChainWrite(' ');
            if (_cssClasses.Count > 0)
            {
                var classes = string.Join(" ", css);
                tw.ChainWrite("class=\"").ChainWrite(classes).Write("\" ");
            }
            if (_attributes.Count > 0)
            {
                foreach (var attribute in _attributes)
                {
                    if (attribute.Value == null) tw.ChainWrite(attribute.Key).ChainWrite(' ');
                    else tw.ChainWrite(attribute.Key).ChainWrite("=\"").ChainWrite(attribute.Value).ChainWrite("\" ");
                }
            }

            if (_style.Count > 0)
            {
                tw.Write("style=\"");
                foreach (var s in _style)
                {
                    tw.ChainWrite(Lookups.Lookup(s.Key))
                        .ChainWrite(':').ChainWrite(s.Value)
                        .ChainWrite(";");
                }
                tw.Write("\" ");
            }
            foreach (var v in _freeOpening)
            {
                tw.ChainWrite(v).ChainWrite(' ');
            }
            if (IsSelfClosing) tw.Write('/');
            tw.Write('>');
        }

        public override void RenderContent(TextWriter tw)
        {
            tw.WriteLine();
            _content.RenderQueue(tw);
            tw.WriteLine();
        }

        public override void RenderClosingTag(TextWriter tw)
        {
            if (string.IsNullOrEmpty(TagName)) return;
            if (IsSelfClosing) return;
            tw.ChainWrite("</").ChainWrite(TagName).ChainWrite('>');
            tw.WriteLine();
        }

        public override void RenderBeforeOpenTag(TextWriter tw)
        {
            _before.RenderQueue(tw);
            Marquite.EventsManager.OnRenderBegin(this);
        }

        public override void RenderAfterClosingTag(TextWriter tw)
        {
            Marquite.EventsManager.OnRenderEnd(this);
            _after.RenderQueue(tw);
        }

        #endregion

        public override string ToString()
        {
            return TagName;
        }

        public override string ToHtmlString()
        {
            return Compile();
        }
    }
}

using System;
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
    /// <typeparam name="TReturn"></typeparam>
    public class BasicHtmlBuilder<TReturn> : RenderingClientBase, IHtmlBuilder
        where TReturn : BasicHtmlBuilder<TReturn>
    {
        #region Private fields
        private RenderingQueue _renderingQueue = new RenderingQueue();
        private readonly IMarquite _marquite;
        private readonly TReturn _this;
        private readonly HashSet<string> _cssClasses = new HashSet<string>();
        private readonly SortedDictionary<Css, string> _style = new SortedDictionary<Css, string>();
        private readonly SortedDictionary<string, string> _attributes = new SortedDictionary<string, string>(StringComparer.Ordinal);
        private string _id;
        private readonly bool _isScoped;
        #endregion

        public BasicHtmlBuilder(IMarquite marquite, string tagName)
        {
            _marquite = marquite;
            _this = (TReturn)(this);
            CategorizedCssClasses = new StringCategory(_cssClasses);
            TagName = tagName;
            Marquite.EventsManager.OnCreated(This);
            if (marquite.ScopeManager.HasActiveScope)
            {
                marquite.ScopeManager.CurrentScope.Append(this);
                _isScoped = true;
            }
        }

        #region Fluent Methods

        public virtual TReturn ChangeTag(string tag)
        {
            TagName = tag;
            return _this;
        }

        public virtual TReturn Id(string id)
        {
            _id = id;
            Attr("id", id);
            return _this;
        }

        public virtual TReturn Css(Css property, string value)
        {
            _style[property] = value;
            return _this;
        }

        public virtual TReturn Attr(string attrName, string value, bool replaceExisting)
        {
            // To self-closed attributes use method 'SelfCloseAttr'
            if (attrName == "class") throw new Exception("Dont try to operate directly with class attribute. Use AddClass and RemoveClass for manupulation with classes.");
            if (string.IsNullOrEmpty(value))
            {
                if (_attributes.ContainsKey(attrName)) _attributes.Remove(attrName);
                return _this;
            }
            if (!replaceExisting && _attributes.ContainsKey(attrName)) return _this;
            _attributes[attrName] = value;
            if (string.Compare(attrName, "id", StringComparison.OrdinalIgnoreCase) == 0)
            {
                _id = value;
            }
            return _this;
        }

        public virtual TReturn Attr(string attrName, string value)
        {
            return Attr(attrName, value, true);
        }

        public virtual TReturn SelfCloseAttr(string attrName)
        {
            if (attrName == "class") throw new Exception("Dont try to operate directly with class attribute. Use AddClass and RemoveClass for manupulation with classes.");
            _attributes[attrName] = null;
            return _this;
        }

        public virtual TReturn Data(string key, string value)
        {
            return Attr("data-" + key, value);
        }

        public virtual TReturn Aria(string key, string value)
        {
            return Attr("aria-" + key, value);
        }

        public virtual TReturn AddClass(string clazz)
        {
            if (string.IsNullOrEmpty(clazz)) return _this;
            if (!_cssClasses.Contains(clazz)) _cssClasses.Add(clazz);
            return _this;
        }

        public virtual TReturn RemoveAttr(string attr)
        {
            if (attr == "class") throw new Exception("Dont try to remove class attribute. Use AddClass and RemoveClass for manupulation with classes.");
            _attributes.Remove(attr);
            return _this;
        }

        public virtual TReturn RemoveClass(string clazz)
        {
            _attributes.Remove(clazz);
            return _this;
        }

        public virtual TReturn RemoveData(string clazz)
        {
            return RemoveAttr("data-" + clazz);
        }

        public virtual TReturn RemoveAria(string clazz)
        {
            return RemoveAttr("aria-" + clazz);
        }

        public virtual TReturn LeadingHtml(string html)
        {
            RenderingQueue.LeadingHtml(html);
            return _this;
        }

        public virtual TReturn LeadingText(string text)
        {
            RenderingQueue.LeadingText(text);
            return _this;
        }

        public virtual TReturn LeadingHtml(IRenderingClient content)
        {
            RenderingQueue.LeadingHtml(content);
            return _this;
        }

        public virtual TReturn TrailingHtml(string html)
        {
            RenderingQueue.TrailingHtml(html);
            return _this;
        }

        public virtual TReturn TrailingText(string text)
        {
            RenderingQueue.TrailingText(text);
            return _this;
        }

        public virtual TReturn TrailingHtml(IRenderingClient content)
        {
            RenderingQueue.TrailingHtml(content);
            return _this;
        }

        public TReturn When(bool condition, Func<TReturn, TReturn> properties)
        {
            if (condition)
            {
                return properties(This);
            }
            return This;
        }

        public TReturn Mixin(Func<TReturn, TReturn> mixin)
        {
            return mixin(This);
        }

        public TNew Convert<TNew>(Func<TReturn, TNew> converter)
        {
            return converter(This);
        }


        #endregion

        #region Protected shortcuts

        public RenderingQueue RenderingQueue { get { return _renderingQueue; } }

        protected void ReplaceClass(string classStartsWith, string anotherClass)
        {
            string already = AutocompleteClass(classStartsWith);
            if (already != null) RemoveClass(already);
            AddClass(anotherClass);
        }

        protected bool IsSelfClosing { get; set; }
        protected string TagName { get; set; }
        public StringCategory CategorizedCssClasses { get; private set; }
        protected IDictionary<string, string> Attributes { get { return _attributes; } }
        protected TReturn This { get { return _this; } }

        public override IMarquite Marquite
        {
            get { return _marquite; }
        }
        protected virtual void FindAndRemoveClass(string clazz)
        {
            var auto = AutocompleteClass(clazz);
            if (auto == null) return;
            RemoveClass(auto);
        }

        protected string AutocompleteClass(string classStartsWith)
        {
            return _cssClasses.FirstOrDefault(c => c.StartsWith(classStartsWith));
        }

        protected bool ContainsClass(string clazz)
        {
            return _cssClasses.Contains(clazz);
        }

        protected string GetAttr(string data)
        {
            if (!_attributes.ContainsKey(data)) return null;
            return _attributes[data];
        }

        protected bool ContainsAttr(string attrKey)
        {
            return _attributes.ContainsKey(attrKey);
        }

        protected string GetData(string data)
        {
            data = "data-" + data;
            return GetAttr(data);
        }
        protected string GetAria(string data)
        {
            data = "aria-" + data;
            return GetAttr(data);
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
                _renderingQueue.CopyTo(ts.Scope.RenderingQueue);
                _renderingQueue = ts.Scope.RenderingQueue;
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
                tw.Write("\"");
            }
            if (IsSelfClosing) tw.Write('/');
            tw.Write('>');
        }

        public override void RenderContent(TextWriter tw)
        {
            RenderingQueue.RenderQueue(tw);
        }

        public override void RenderClosingTag(TextWriter tw)
        {
            if (string.IsNullOrEmpty(TagName)) return;
            if (IsSelfClosing) return;
            tw.ChainWrite("</").ChainWrite(TagName).ChainWrite('>');
        }

        public override void RenderBeforeOpenTag(TextWriter tw)
        {
            Marquite.EventsManager.OnRenderBegin(This);
        }

        public override void RenderAfterClosingTag(TextWriter tw)
        {
            Marquite.EventsManager.OnRenderEnd(This);
        }

        #endregion

        public string IdVal { get { return _id; } }

        public override string ToString()
        {
            return TagName;
        }

        public override string ToHtmlString()
        {
            return Compile();
        }

        public void MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting)
        {
            if (attributes != null)
            {
                foreach (var entry in attributes)
                {
                    string key = System.Convert.ToString(entry.Key, CultureInfo.InvariantCulture);
                    string value = System.Convert.ToString(entry.Value, CultureInfo.InvariantCulture);
                    if (key == "class")
                    {
                        if (value.Contains(" "))
                        {
                            var classes = value.Split(' ');
                            foreach (var @class in classes)
                            {
                                AddClass(@class);
                            }
                        }
                        else
                        {
                            AddClass(value);
                        }
                    }
                    else
                    {
                        Attr(key, value, replaceExisting);
                    }
                }
            }
        }

        public void MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes)
        {
            MergeAttributes(attributes, replaceExisting: false);
        }

        #region Nongeneric

        string IHtmlBuilder.Tag
        {
            get { return TagName; }
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_Id(string id)
        {
            return Id(id);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_Css(Css property, string value)
        {
            return Css(property, value);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_Attr(string attrName, string value, bool replaceExisting)
        {
            return Attr(attrName, value, replaceExisting);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_Attr(string attrName, string value)
        {
            return Attr(attrName, value);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_SelfCloseAttr(string attrName)
        {
            return SelfCloseAttr(attrName);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_Data(string key, string value)
        {
            return Data(key, value);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_Aria(string key, string value)
        {
            return Aria(key, value);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_AddClass(string clazz)
        {
            return AddClass(clazz);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_RemoveAttr(string attr)
        {
            return RemoveAttr(attr);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_RemoveClass(string clazz)
        {
            return RemoveClass(clazz);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_RemoveData(string clazz)
        {
            return RemoveData(clazz);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_RemoveAria(string clazz)
        {
            return RemoveAria(clazz);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_LeadingHtml(string html)
        {
            return LeadingHtml(html);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_LeadingText(string text)
        {
            return LeadingText(text);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_LeadingHtml(IRenderingClient content)
        {
            return LeadingHtml(content);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_TrailingHtml(string html)
        {
            return TrailingHtml(html);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_TrailingText(string text)
        {
            return TrailingText(text);
        }

        IHtmlBuilder IHtmlBuilder.NonGeneric_TrailingHtml(IRenderingClient content)
        {
            return TrailingHtml(content);
        }

        #endregion
    }
}

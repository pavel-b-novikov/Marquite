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
    public class BasicHtmlBuilder<TReturn> : IHtmlString, IHtmlBuilder where TReturn : BasicHtmlBuilder<TReturn>
    {
        #region Private fields
        private readonly LinkedList<RenderingItem> _renderingQueue = new LinkedList<RenderingItem>();
        private readonly Marquite _marquite;
        private readonly TReturn _this;
        private readonly HashSet<string> _cssClasses = new HashSet<string>();
        private readonly SortedDictionary<Css, string> _style = new SortedDictionary<Css, string>();
        private readonly SortedDictionary<string, string> _attributes = new SortedDictionary<string, string>(StringComparer.Ordinal);
        private string _id;
        #endregion

        public BasicHtmlBuilder(Marquite marquite, string tagName)
        {
            _marquite = marquite;
            _this = (TReturn)(this);
            TagsCategory = new StringCategory(_cssClasses);
            TagName = tagName;
            Marquite.EventsManager.OnCreated(This);
        }

        #region Fluent Methods

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
            return Attr(attrName, value, false);
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
            Lead(html);
            return _this;
        }

        public virtual TReturn LeadingText(string text)
        {
            Lead(text, encode: true);
            return _this;
        }

        public virtual TReturn LeadingHtml(IRenderingClient content)
        {
            Lead(content);
            return _this;
        }

        public virtual TReturn TrailingHtml(string html)
        {
            Trail(html);
            return _this;
        }

        public virtual TReturn TrailingText(string text)
        {
            Trail(text, encode: true);
            return _this;
        }

        public virtual TReturn TrailingHtml(IRenderingClient content)
        {
            Trail(content);
            return _this;
        }

        private bool _renderContentAtTop;
        public virtual TReturn PullInnerContentUp()
        {
            _renderContentAtTop = true;
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

        protected void ReplaceClass(string classStartsWith, string anotherClass)
        {
            string already = AutocompleteClass(classStartsWith);
            if (already != null) RemoveClass(already);
            AddClass(anotherClass);
        }

        protected bool IsSelfClosing { get; set; }

        protected virtual void ClearQueue()
        {
            _renderingQueue.Clear();
        }

        protected virtual void RenderQueue(TextWriter tw)
        {
            foreach (var renderingItem in _renderingQueue)
            {
                tw.RenderItem(renderingItem);
            }
            _renderingQueue.Clear();
        }

        protected bool HasPendingItems { get { return _renderingQueue.Count > 0; } }

        protected string TagName { get; set; }
        public StringCategory TagsCategory { get; private set; }
        protected IDictionary<string, string> Attributes { get { return _attributes; } }
        protected TReturn This { get { return _this; } }

        public Marquite Marquite
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

        #region Rendering queue
        protected void Trail(string content, string wrapTag = null, bool encode = false, string wrappingTagAttrs = null)
        {
            _renderingQueue.AddLast(new RenderingItem(wrapTag, null, content, encode, wrappingTagAttrs));
        }

        protected void Trail(IRenderingClient client, string wrapTag = null, string wrappingTagAttrs = null)
        {
            _renderingQueue.AddLast(new RenderingItem(wrapTag, client, null, wrappingTagAttrs: wrappingTagAttrs));
        }

        protected void Lead(IRenderingClient client, string wrapTag = null, string wrappingTagAttrs = null)
        {
            _renderingQueue.AddFirst(new RenderingItem(wrapTag, client, null, wrappingTagAttrs: wrappingTagAttrs));
        }

        protected void Lead(string content, string wrapTag = null, bool encode = false, string wrappingTagAttrs = null)
        {
            _renderingQueue.AddFirst(new RenderingItem(wrapTag, null, content, encode, wrappingTagAttrs: wrappingTagAttrs));
        }

        #endregion

        #region Rendering

        protected virtual void PrepareForRender()
        {

        }

        public virtual MvcHtmlString Render()
        {
            PrepareForRender();
            Marquite.GetTopmostWriter().RenderClient(this);
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
            PrepareForRender();
            return ContinousRenderer.Render(this);
        }

        public virtual string Compile(bool condition)
        {
            if (condition)
            {
                PrepareForRender();
                return ContinousRenderer.Render(this);
            }
            return String.Empty;
        }

        public virtual InnerTagScope Open()
        {
            PrepareForRender();
            InnerTagScope its = new InnerTagScope(_renderContentAtTop);
            its.Render(this);
            return its;
        }

        #endregion

        #region Rendering pipeline

        protected virtual void RenderBeforeOpeningTag(TextWriter tw) { }

        protected virtual void RenderOpeningTag(TextWriter tw)
        {
            if (string.IsNullOrEmpty(TagName)) return;
            
            var css = _cssClasses.ToArray();

            tw.ChainWrite('<').ChainWrite(TagName).ChainWrite(' ');
            if (_cssClasses.Count > 0)
            {
                tw.Write("class=\"");
                css.RevForEach(c => tw.ChainWrite(c).ChainWrite(' '));
                tw.Write("\" ");
            }
            if (_attributes.Count > 0)
            {
                foreach (var attribute in _attributes)
                {
                    if (attribute.Value == null)
                    {
                        tw.ChainWrite(attribute.Key).ChainWrite(' ');
                    }
                    else
                    {
                        tw.ChainWrite(attribute.Key).ChainWrite("=\"").ChainWrite(attribute.Value).ChainWrite("\" ");
                    }
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

        protected virtual void RenderAfterOpeningTag(TextWriter tw) { }

        protected virtual void RenderContent(TextWriter tw)
        {
            RenderQueue(tw);
        }

        protected virtual void RenderBeforeClosingTag(TextWriter tw) { }
        protected virtual void RenderClosingTag(TextWriter tw)
        {
            if (string.IsNullOrEmpty(TagName)) return;
            tw.ChainWrite("</").ChainWrite(TagName).ChainWrite('>');
        }

        protected virtual void RenderAfterClosingTag(TextWriter tw) { }


        void IRenderingClient.RenderBeforeOpenTag(TextWriter tw)
        {
            Marquite.EventsManager.OnRenderBegin(This);
            RenderBeforeOpeningTag(tw);
        }

        void IRenderingClient.RenderOpeningTag(TextWriter tw)
        {
            RenderOpeningTag(tw);
        }

        void IRenderingClient.RenderAfterOpeningTag(TextWriter tw)
        {
            RenderAfterOpeningTag(tw);
        }

        void IRenderingClient.RenderContent(TextWriter tw)
        {
            RenderContent(tw);
        }

        void IRenderingClient.RenderBeforeClosingTag(TextWriter tw)
        {
            if (IsSelfClosing) return;
            RenderBeforeClosingTag(tw);
        }

        void IRenderingClient.RenderClosingTag(TextWriter tw)
        {
            if (IsSelfClosing) return;
            RenderClosingTag(tw);
        }

        void IRenderingClient.RenderAfterClosingTag(TextWriter tw)
        {
            if (IsSelfClosing) return;
            RenderAfterClosingTag(tw);
            Marquite.EventsManager.OnRenderEnd(This);
        }

        #endregion

        public string IdVal { get { return _id; } }

        public int RenderingQueueCount { get { return _renderingQueue.Count; } }

        public override string ToString()
        {
            return TagName;
        }

        public virtual string ToHtmlString()
        {

            return Render().ToString();
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

        IHtmlBuilder IHtmlBuilder.NonGeneric_PullInnerContentUp()
        {
            return PullInnerContentUp();
        }
        #endregion
    }
}

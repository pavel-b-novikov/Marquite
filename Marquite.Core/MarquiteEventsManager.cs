using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core
{
    public class MarquiteEventsManager
    {
        public enum EventType
        {
            TagCreated,
            TagRenderBegin,
            TagRenderEnd
        }

        private readonly Dictionary<Type, List<object>> _createdActions = new Dictionary<Type, List<object>>();
        private readonly Dictionary<Type, List<object>> _renderBeginActions = new Dictionary<Type, List<object>>();
        private readonly Dictionary<Type, List<object>> _renderEndActions = new Dictionary<Type, List<object>>();


        private List<object> GetOrCreateList<TTagType>
            (Dictionary<Type, List<object>> dict)
            where TTagType : IHtmlBuilder
        {
            List<object> result;
            var t = typeof(TTagType);
            bool present = dict.TryGetValue(t, out result);
            if (present) return result;
            result = new List<object>(10);
            dict[t] = result;
            return result;
        }

        public void Subscribe<TTagType>(Action<TTagType> action)
            where TTagType : IHtmlBuilder
        {
            Subscribe(action, _createdActions);
            Subscribe(action, _renderBeginActions);
            Subscribe(action, _renderEndActions);
        }

        public void Subscribe<TTagType>(Action<TTagType> action, EventType eventType)
             where TTagType : IHtmlBuilder
        {
            Dictionary<Type, List<object>> list = null;
            switch (eventType)
            {
                case EventType.TagCreated:
                    list = _createdActions;
                    break;
                case EventType.TagRenderBegin:
                    list = _renderBeginActions;
                    break;
                default:
                    list = _renderEndActions;
                    break;
            }

            Subscribe(action,list);
        }

        private void Subscribe<TTagType>(Action<TTagType> action, Dictionary<Type, List<object>> dict)
            where TTagType : IHtmlBuilder
        {
            var actions = GetOrCreateList<TTagType>(dict);
            actions.Add(action);
        }

        internal void OnCreated<TTagType>(TTagType tag) where TTagType : IHtmlBuilder
        {
            ExecuteAction(_createdActions, tag);
        }

        internal void OnRenderBegin<TTagType>(TTagType tag) where TTagType : IHtmlBuilder
        {
            ExecuteAction(_renderBeginActions, tag);
        }

        internal void OnRenderEnd<TTagType>(TTagType tag) where TTagType : IHtmlBuilder
        {
            ExecuteAction(_renderEndActions, tag);
        }

        private void ExecuteAction<TTagType>(Dictionary<Type, List<object>> Actions, TTagType tag)
             where TTagType : IHtmlBuilder
        {
            Actions.Where(h => h.Key == typeof(TTagType))
                .SelectMany(c => c.Value)
                .ToList()
                .ForEach(h => ((Action<IHtmlBuilder>)h)(tag));
        }
    }
}

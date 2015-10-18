using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Marquite.Angular.Expressions;

namespace Marquite.Angular
{
    /// <summary>
    /// Helper for evaluation of fields/methods bindings
    /// </summary>
    /// <typeparam name="TModel">Your ViewModel type (interfaces welcome)</typeparam>
    public class NgContext<TModel> : INgContext
    {
        public string ModelName { get; set; }

        public NgContext(string modelName = null)
        {
            ModelName = modelName;
        }

        public IAngularInExpression<TElement,TModel> In<TElement>(string variableName,
            Expression<Func<TModel, IEnumerable<TElement>>> collection, out NgCollectionContext<TElement, TModel> context)
        {
            context = new NgCollectionContext<TElement, TModel>(variableName);
            return new NgInExpression<TElement, TModel>(Translate(collection),context,variableName);
        }

        public IAngularInExpression<TElement, TModel> In<TElement>(string variableName,
            string collectionExpression, out NgCollectionContext<TElement, TModel> context)
        {
            context = new NgCollectionContext<TElement, TModel>(variableName);
            return new NgInExpression<TElement, TModel>(collectionExpression, context, variableName);
        }

        public IAngularExpression Bind<TData>(Expression<Func<TModel, TData>> property)
        {
            return Translate(property);
        }

        public IAngularExpression Command<TData>(Expression<Func<AngularEventContext<TModel>, TData>> method)
        {
            return Translate(method);
        }

        public IAngularExpression Command(Expression<Action<AngularEventContext<TModel>>> method)
        {
            return Translate(method);
        }

        private NgExpression Translate(LambdaExpression property)
        {
            AngularLambdaExpressionVisitor visitor = new AngularLambdaExpressionVisitor(property);
            visitor.Visit(property.Body);
            visitor.BindModel(ModelName);
            return visitor.Retrieve();
        }
    }
}

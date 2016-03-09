using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular
{
    public class NgFormContextWrapper<TModel>
    {
        [IsModel]
        public TModel Model { get; set; }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateParametrizedPristine")]
        public bool Pristine<TData>(Expression<Func<TModel, TData>> field)
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslatePristine")]
        public bool Pristine()
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateParametrizedDirty")]
        public bool Dirty<TData>(Expression<Func<TModel, TData>> field)
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateDirty")]
        public bool Dirty()
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateParametrizedValid")]
        public bool Valid<TData>(Expression<Func<TModel, TData>> field)
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateValid")]
        public bool Valid()
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateParametrizedInvalid")]
        public bool Invalid<TData>(Expression<Func<TModel, TData>> field)
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateInvalid")]
        public bool Invalid()
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateParametrizedTouched")]
        public bool Touched<TData>(Expression<Func<TModel, TData>> field)
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateTouched")]
        public bool Touched()
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateParametrizedPending")]
        public bool Pending<TData>(Expression<Func<TModel, TData>> field)
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslatePending")]
        public bool Pending()
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateSubmitted")]
        public bool Submitted()
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateParametrizedError")]
        public bool Error<TData>(Expression<Func<TModel, TData>> field)
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateError")]
        public bool Error()
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateParametrizedErrorBuiltInToken")]
        public bool Error<TData>(Expression<Func<TModel, TData>> field, BuiltInValidatorToken validationToken)
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateParametrizedErrorStringToken")]
        public bool Error<TData>(Expression<Func<TModel, TData>> field, string validationToken)
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateErrorBuiltInToken")]
        public bool Error(BuiltInValidatorToken validationToken)
        {
            return true;
        }

        [CustomMethodCallTranslation(typeof(Translations), "TranslateErrorStringToken")]
        public bool Error(string validationToken)
        {
            return true;
        }
    }
}

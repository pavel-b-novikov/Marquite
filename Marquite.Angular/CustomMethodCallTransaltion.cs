using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Marquite.Angular.Expressions;

namespace Marquite.Angular
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple = false)]
    public class CustomMethodCallTranslationAttribute : Attribute
    {
        public MethodInfo TranslationFunction { get; private set; }

        public CustomMethodCallTranslationAttribute(Type translationClass,string translationMethodName)
        {
            TranslationFunction = translationClass.GetMethod(translationMethodName);
        }
    }
}

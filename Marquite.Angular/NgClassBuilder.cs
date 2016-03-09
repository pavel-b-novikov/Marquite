using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular
{
    public class NgClassBuilder
    {
        private readonly List<Tuple<string, string>> _classesToExpressions = new List<Tuple<string, string>>();

        public NgClassBuilder Class(string className, string expression)
        {
            _classesToExpressions.Add(new Tuple<string, string>(className, expression));
            return this;
        }

        public NgClassBuilder Class(string className, IAngularExpression expression)
        {
            return Class(className, expression.Build());
        }

        public string Build()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");
            for (int index = 0; index < _classesToExpressions.Count; index++)
            {
                var classesToExpression = _classesToExpressions[index];
                sb.AppendFormat("'{0}' : {1}", classesToExpression.Item1, classesToExpression.Item2);
                if (index != _classesToExpressions.Count - 1) sb.Append(", ");
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}

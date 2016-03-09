using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Marquite.Angular.Expressions
{
    class AngularLambdaExpressionVisitor : ExpressionVisitor
    {
        private readonly Stack<NgExpression> _resultsStack = new Stack<NgExpression>();
        private readonly List<NgUnboundExpression> _unboundModelReferences = new List<NgUnboundExpression>();
        private readonly LambdaExpression _rootExpression;
        private readonly bool _isParametrizedByEventContext;

        public List<NgUnboundExpression> UnboundModelReferences
        {
            get { return _unboundModelReferences; }
        }

        public void BindModel(string modelLiteral)
        {
            foreach (var unboundModelReference in _unboundModelReferences)
            {
                unboundModelReference.Boundee = new NgLiteralExpression() {Literal = modelLiteral};
            }
        }

        public void Bind(NgExpression expression)
        {
            foreach (var unboundModelReference in _unboundModelReferences)
            {
                unboundModelReference.Boundee = expression;
            }
        }

        public void BindEmpty()
        {
            foreach (var unboundModelReference in _unboundModelReferences)
            {
                unboundModelReference.IsEmpty = true;
            }
        }

        public override Expression Visit(Expression node)
        {
            if (node.NodeType == ExpressionType.Convert)
            {
                UnaryExpression uex = (UnaryExpression)node;
                return base.Visit(uex.Operand);
            }
            return base.Visit(node);

        }

        public AngularLambdaExpressionVisitor(LambdaExpression rootExpression)
        {
            _rootExpression = rootExpression;
            var param = _rootExpression.Parameters[0];
            var ptype = param.Type;
            if (ptype.IsGenericType && ptype.GetGenericTypeDefinition() == typeof(NgEventContext<>))
            {
                _isParametrizedByEventContext = true;
            }
        }

        private void Return(NgExpression expr)
        {
            _resultsStack.Push(expr);
        }

        public NgExpression Retrieve()
        {
            return _resultsStack.Pop();
        }

        private bool DetectModelMemberAccess(Expression node)
        {
            return !_isParametrizedByEventContext && node is ParameterExpression;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (DetectModelMemberAccess(node.Expression))
            {
                var ngex = new NgUnboundExpression();
                var prop = new NgMemberExpression() { Accessed = ngex, MemberName = node.Member.Name };
                Return(prop);
                _unboundModelReferences.Add(ngex);
                return node;
            }

            var attr = node.Member.GetCustomAttribute<OverrideNameAttribute>();
            if (attr != null)
            {
                Return(new NgLiteralExpression() { Literal = attr.Name });
                return node;
            }

            var modelAttr = node.Member.GetCustomAttribute<IsModelAttribute>();
            if (modelAttr != null)
            {
                var ngex = new NgUnboundExpression();
                _unboundModelReferences.Add(ngex);
                Return(ngex);
                return node;
            }


            Visit(node.Expression);
            var accessedExpression = Retrieve();
            Return(new NgMemberExpression { Accessed = accessedExpression, MemberName = node.Member.Name });
            return node;
        }

        protected override Expression VisitIndex(IndexExpression node)
        {
            Visit(node.Object);
            var ind = Retrieve();
            Visit(node.Arguments[0]);
            var indexee = Retrieve();
            Return(new NgIndexerExpression { ExpressionToIndex = ind, Index = indexee });
            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var customAttr = node.Method.GetCustomAttribute<CustomMethodCallTranslationAttribute>();
            if (customAttr != null)
            {
                var result = customAttr.TranslationFunction.Invoke(null, new object[] { node, this });
                Return((NgExpression)result);
                return node;
            }

            NgMemberExpression callee;
            if (DetectModelMemberAccess(node.Object))
            {
                var ngex = new NgUnboundExpression();
                callee = new NgMemberExpression() { Accessed = ngex, MemberName = node.Method.Name };
                _unboundModelReferences.Add(ngex);
            }
            else
            {
                Visit(node.Object);
                callee = new NgMemberExpression() { Accessed = Retrieve(), MemberName = node.Method.Name };
            }
            var methodCall = new NgCallExpression { ExpressionToCall = callee };
            foreach (var expression in node.Arguments)
            {
                Visit(expression);
                var arg = Retrieve();
                methodCall.Arguments.Add(arg);
            }
            Return(methodCall);
            return node;
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            Visit(node.Operand);
            var operand = Retrieve();
            var sym = GetNodeSymbol(node.NodeType);
            Return(new NgUnaryExpression { Expression = operand, Symbol = sym });
            return node;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Visit(node.Left);
            var left = Retrieve();
            Visit(node.Right);
            var right = Retrieve();
            string symbol = GetNodeSymbol(node.NodeType);
            Return(new NgBinaryExpression { Left = left, Right = right, Symbol = symbol });
            return node;
        }

        private string GetNodeSymbol(ExpressionType type)
        {
            switch (type)
            {
                case ExpressionType.Add: return "+";
                case ExpressionType.Subtract: return "-";
                case ExpressionType.Divide: return "/";
                case ExpressionType.Multiply: return "*";
                case ExpressionType.AddAssign: return "+=";
                case ExpressionType.SubtractAssign: return "-=";
                case ExpressionType.DivideAssign: return "/=";
                case ExpressionType.MultiplyAssign: return "*=";
                case ExpressionType.And: return "&";
                case ExpressionType.AndAlso: return "&&";
                case ExpressionType.AndAssign: return "&=";
                case ExpressionType.Or: return "|";
                case ExpressionType.OrElse: return "||";
                case ExpressionType.OrAssign: return "|=";
                case ExpressionType.Not: return "!";
                case ExpressionType.Equal: return "==";
                case ExpressionType.NotEqual: return "!=";
                case ExpressionType.Negate: return "-";
                case ExpressionType.UnaryPlus: return "+";
                case ExpressionType.Assign: return "=";
                default:
                    throw new Exception("Invalid expression type");
            }
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return base.VisitParameter(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Value == null)
            {
                Return(new NgLiteralExpression { Literal = "null" });
                return node;
            }
            if (node.Type == typeof(string))
            {
                var s = "\'" + node.Value.ToString().Replace("\"", "\\\"") + "\'";
                Return(new NgLiteralExpression { Literal = s });
                return node;
            }

            if (node.Type == typeof(bool))
            {
                var b = (bool)node.Value;
                Return(new NgLiteralExpression { Literal = b ? "true" : "false" });
                return node;
            }
            Return(new NgLiteralExpression { Literal = node.Value.ToString() });
            return node;
        }
    }
}

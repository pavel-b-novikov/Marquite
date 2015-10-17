using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Marquite.Angular.Expressions
{
    class AngularLambdaExpressionVisitor : ExpressionVisitor
    {
        private readonly Stack<NgExpression> _resultsStack = new Stack<NgExpression>();
        private static readonly MethodInfo VarContextMethod;
        private readonly List<NgLiteralExpression> _unboundModelReferences = new List<NgLiteralExpression>();
        private readonly LambdaExpression _rootExpression;
        private bool _isParametrizedByEventContext;
        public void BindModel(string modelLiteral)
        {
            foreach (var unboundModelReference in _unboundModelReferences)
            {
                unboundModelReference.Literal = modelLiteral;
            }
        }

        static AngularLambdaExpressionVisitor()
        {
            VarContextMethod = typeof(AngularEventContext<>).GetMethod("Var");
        }

        public AngularLambdaExpressionVisitor(LambdaExpression rootExpression)
        {
            _rootExpression = rootExpression;
            var param = _rootExpression.Parameters[0];
            var ptype = param.Type;
            if (ptype.IsGenericType && ptype.GetGenericTypeDefinition() == typeof(AngularEventContext<>))
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

        private bool DetectModelMemberAccess(MemberExpression node)
        {
            return !_isParametrizedByEventContext && node.Expression is ParameterExpression;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (DetectModelMemberAccess(node))
            {
                var ngex = new NgLiteralExpression { Literal = "??model??", IsModelReference = true };
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
                var ngex = new NgLiteralExpression { Literal = "??model??", IsModelReference = true };
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
            if (node.Method.IsGenericMethod && node.Method.GetGenericMethodDefinition() == VarContextMethod)
            {
                var arg = node.Arguments[0] as ConstantExpression;
                if (arg == null) throw new Exception("Please specify only constant strings as parameter for .Var call");
                Return(new NgLiteralExpression { Literal = arg.Value.ToString() });
                return node;
            }

            Visit(node.Object);
            var callee = new NgMemberExpression() { Accessed = Retrieve(), MemberName = node.Method.Name };

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
                var s = node.Value.ToString().Replace("\"", "\\\"");
                Return(new NgLiteralExpression { Literal = s });
            }

            if (node.Type == typeof(bool))
            {
                var b = (bool)node.Value;
                Return(new NgLiteralExpression { Literal = b ? "true" : "false" });
            }
            Return(new NgLiteralExpression { Literal = node.Value.ToString() });
            return node;
        }
    }
}

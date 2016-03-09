using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Marquite.Angular.Expressions;

namespace Marquite.Angular
{
    internal static class Translations
    {
        private const string Pristine = "$pristine";
        private const string Dirty = "$dirty";
        private const string Valid = "$valid";
        private const string Invalid = "$invalid";
        private const string Pending = "$pending";
        private const string Submitted = "$submitted";
        private const string Error = "$error";
        private const string Touched = "$touched";

        public static NgExpression TranslateVar(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            var node = n as MethodCallExpression;
            var arg = node.Arguments[0] as ConstantExpression;
            if (arg == null) throw new Exception("Please specify only constant strings as parameter for .Var call");
            return new NgLiteralExpression { Literal = arg.Value.ToString() };
        }

        public static NgExpression TranslateParametrizedPristine(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            return TranslateFormPropertyAccess(n as MethodCallExpression, Pristine, visitor);
        }

        public static NgExpression TranslatePristine(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            return TranslateFormProperty(n as MethodCallExpression, Pristine, visitor);
        }

        public static NgExpression TranslateParametrizedDirty(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            return TranslateFormPropertyAccess(n as MethodCallExpression, Dirty, visitor);
        }

        public static NgExpression TranslateDirty(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            return TranslateFormProperty(n as MethodCallExpression, Dirty, visitor);
        }

        public static NgExpression TranslateParametrizedValid(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            return TranslateFormPropertyAccess(n as MethodCallExpression, Valid, visitor);
        }

        public static NgExpression TranslateValid(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            return TranslateFormProperty(n as MethodCallExpression, Valid, visitor);
        }

        public static NgExpression TranslateParametrizedInvalid(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            return TranslateFormPropertyAccess(n as MethodCallExpression, Invalid, visitor);
        }

        public static NgExpression TranslateInvalid(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            return TranslateFormProperty(n as MethodCallExpression, Invalid, visitor);
        }

        public static NgExpression TranslateParametrizedPending(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            return TranslateFormPropertyAccess(n as MethodCallExpression, Pending, visitor);
        }

        public static NgExpression TranslatePending(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            return TranslateFormProperty(n as MethodCallExpression, Pending, visitor);
        }

        public static NgExpression TranslateParametrizedTouched(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            return TranslateFormPropertyAccess(n as MethodCallExpression, Touched, visitor);
        }

        public static NgExpression TranslateTouched(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            return TranslateFormProperty(n as MethodCallExpression, Touched, visitor);
        }

        public static NgExpression TranslateSubmitted(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            return TranslateFormProperty(n as MethodCallExpression, Submitted, visitor);
        }

        #region Errors
        public static NgExpression TranslateParametrizedError(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            return TranslateFormPropertyAccess(n as MethodCallExpression, Error, visitor);
        }

        public static NgExpression TranslateError(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            return TranslateFormProperty(n as MethodCallExpression, Error, visitor);
        }

        public static NgExpression TranslateParametrizedErrorBuiltInToken(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            string token = ExtractToken((n as MethodCallExpression).Arguments[1]);
            return TranslateParametrizedErrorToken(n as MethodCallExpression, visitor, token);
        }

        private static string ExtractToken(Expression ex)
        {
            if (ex.NodeType == ExpressionType.Constant)
            {
                var c = ex as ConstantExpression;
                if (c.Type == typeof(BuiltInValidatorToken))
                {
                    return c.Value.ToString().ToLower();
                }

                if (c.Type == typeof(string))
                {
                    return (string)c.Value;
                }
            }
            throw new Exception(string.Format("Invalid validation token expression: {0}", ex));
        }

        public static NgExpression TranslateParametrizedErrorStringToken(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            string token = ExtractToken((n as MethodCallExpression).Arguments[1]);
            return TranslateParametrizedErrorToken(n as MethodCallExpression, visitor, token);
        }

        public static NgExpression TranslateErrorBuiltInToken(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            string token = ExtractToken((n as MethodCallExpression).Arguments[0]);
            return TranslateErrorToken(n as MethodCallExpression, visitor, token);
        }

        public static NgExpression TranslateErrorStringToken(Expression n, AngularLambdaExpressionVisitor visitor)
        {
            string token = ExtractToken((n as MethodCallExpression).Arguments[0]);
            return TranslateErrorToken(n as MethodCallExpression, visitor, token);
        }
        #endregion

        #region Errors core
        private static NgExpression TranslateParametrizedErrorToken(Expression n, AngularLambdaExpressionVisitor visitor, string token)
        {
            var ngex = TranslateParametrizedError(n, visitor);
            return new NgMemberExpression()
            {
                Accessed = ngex,
                MemberName = token
            };
        }

        private static NgExpression TranslateErrorToken(Expression n, AngularLambdaExpressionVisitor visitor, string token)
        {
            var ngex = TranslateError(n, visitor);
            return new NgMemberExpression()
            {
                Accessed = ngex,
                MemberName = token
            };
        }
        #endregion

        private static NgExpression TranslateFormPropertyAccess(MethodCallExpression expr, string formProperty, AngularLambdaExpressionVisitor visitor)
        {
            var lambdaArg = expr.Arguments[0] as UnaryExpression;
            var operand = lambdaArg.Operand as LambdaExpression;
            AngularLambdaExpressionVisitor handyVisitor = new AngularLambdaExpressionVisitor(operand);
            handyVisitor.Visit(operand.Body);
            var acc = new NgUnboundExpression();
            visitor.UnboundModelReferences.Add(acc);
            handyVisitor.Bind(acc);

            var result = handyVisitor.Retrieve();
            var mex = new NgMemberExpression()
            {
                Accessed = result,
                MemberName = formProperty
            };

            return mex;
        }

        private static NgExpression TranslateFormProperty(MethodCallExpression expr, string formProperty, AngularLambdaExpressionVisitor visitor)
        {
            var acc = new NgUnboundExpression();
            visitor.UnboundModelReferences.Add(acc);
            var result = new NgMemberExpression()
            {
                Accessed = acc,
                MemberName = formProperty
            };
            return result;
        }
    }
}

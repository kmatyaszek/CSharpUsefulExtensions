using System;
using System.Linq.Expressions;

namespace CSharpUsefulExtensions
{
    public static class ArgumentChecking
    {
        public static void ThrowIfNull<T>(this T argument) where T : class
        {
            if (argument == null)
                throw new ArgumentNullException();
        }

        public static void ThrowIfNull<T>(this T argument, string parameterName) where T : class
        {
            if (argument == null)
                throw new ArgumentNullException(parameterName);
        }

        public static void ThrowIfNull<T>(this T argument, string parameterName, string message) where T : class
        {            
            if (argument == null)
                throw new ArgumentNullException(parameterName, message);
        }

        public static void ThrowIfNull<T>(this T argument, Expression<Func<T>> exprParameterName) where T : class
        {
            if (argument == null)
                throw new ArgumentNullException(GetName(exprParameterName));
        }

        public static void ThrowIfNull<T>(this T argument, Expression<Func<T>> exprParameterName, string message) where T : class
        {
            if (argument == null)
                throw new ArgumentNullException(GetName(exprParameterName), message);
        }

        private static string GetName<T>(Expression<Func<T>> expr)
        {
            var body = ((MemberExpression)expr.Body);
            return body.Member.Name;
        }
    }
}
   
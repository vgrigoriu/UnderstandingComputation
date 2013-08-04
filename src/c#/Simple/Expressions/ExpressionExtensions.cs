using System.Globalization;

namespace Simple.Expressions
{
    public static class ExpressionExtensions
    {
        /// <summary>
        /// returns a string representation of the expression.
        /// </summary>
        /// <param name="expression">The expression to inspect.</param>
		public static string Inspect<T>(this IExpression<T> expression)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "«{0}»",
                expression);
        }
    }
}

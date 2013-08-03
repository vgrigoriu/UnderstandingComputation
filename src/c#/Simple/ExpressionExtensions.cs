using System.Globalization;

namespace Simple
{
    public static class ExpressionExtensions
    {
        /// <summary>
        /// returns a string representation of the expression.
        /// </summary>
        /// <param name="expression">The expression to inspect.</param>
		public static string Inspect(this IExpression expression)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "«{0}»",
                expression);
        }
    }
}

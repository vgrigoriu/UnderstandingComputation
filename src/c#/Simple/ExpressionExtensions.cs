using System.Globalization;

namespace Simple
{
    public static class ExpressionExtensions
    {
        public static string Inspect(this IExpression expression)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "«{0}»",
                expression);
        }
    }
}

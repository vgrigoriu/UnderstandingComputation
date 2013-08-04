using System.Globalization;

namespace Simple
{
    public static class InspectExtensions
    {
        /// <summary>
        /// returns a string representation of the expression.
        /// </summary>
        /// <param name="element">The expression to inspect.</param>
		public static string Inspect(this IReducible element)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "«{0}»",
                element);
        }
    }
}

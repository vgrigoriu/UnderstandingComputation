using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using Simple.Expressions;

namespace Simple
{
    public class Environment : IEnvironment
    {
        private readonly ImmutableDictionary<string, object> values;

        private Environment(ImmutableDictionary<string, object> values)
        {
            this.values = values;
        }

        public static IEnvironment Empty
        {
            get
            {
                return new Environment(ImmutableDictionary.Create<string, object>());
            }
        }

        public IExpression<T> GetValue<T>(string variableName)
        {
            return (IExpression<T>)values[variableName];
        }

        public IEnvironment AddValue<T>(string variableName, IExpression<T> value)
        {
            return new Environment(values.SetItem(variableName, value));
        }

        public override string ToString()
        {
            var items = from x in values
                        orderby x.Key
                        select string.Format(
                            CultureInfo.InvariantCulture,
                            "{0} => {1}",
                            x.Key,
                            ((IReducible)x.Value).Inspect());

            return string.Format(
                CultureInfo.InvariantCulture,
                "{{{0}}}",
                string.Join(", ", items));
        }
    }
}
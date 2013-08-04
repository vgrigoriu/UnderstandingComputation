using System.Collections.Immutable;
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
            return (IExpression<T>) values[variableName];
        }

        public IEnvironment AddValue<T>(string variableName, IExpression<T> value)
        {
            return new Environment(values.Add(variableName, value));
        }
    }
}
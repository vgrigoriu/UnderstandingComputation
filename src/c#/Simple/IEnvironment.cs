using System.Collections.Generic;

namespace Simple
{
    public interface IEnvironment
    {
        IExpression<T> GetValue<T>(string variableName);
    }

    public class Environment : IEnvironment
    {
        private readonly Dictionary<string, object> values = new Dictionary<string, object>();

        public void SetVariable<T>(string variableName, IExpression<T> value)
        {
            values[variableName] = value;
        }

        public IExpression<T> GetValue<T>(string variableName)
        {
            return (IExpression<T>) values[variableName];
        }
    }
}

using System.Collections.Generic;
using Simple.Expressions;

namespace Simple
{
    public interface IEnvironment
    {
        IExpression<T> GetValue<T>(string variableName);
        IEnvironment AddValue<T>(string variableName, IExpression<T> value);
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

        public IEnvironment AddValue<T>(string variableName, IExpression<T> value)
        {
            throw new System.NotImplementedException();
        }
    }
}

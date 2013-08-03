using System.Collections.Generic;

namespace Simple
{
    public interface IEnvironment
    {
        T GetValue<T>(string variableName);
    }

    public class Environment : IEnvironment
    {
        private readonly Dictionary<string, object> values = new Dictionary<string, object>();

        public void SetVariable<T>(string variableName, T value)
        {
            values[variableName] = value;
        }

        public T GetValue<T>(string variableName)
        {
            return (T) values[variableName];
        }
    }
}

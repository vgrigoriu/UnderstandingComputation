using System.Collections.Generic;

namespace Simple
{
    public interface IEnvironment
    {
        IExpression<T> GetValue<T>(string variableName);
    }
}

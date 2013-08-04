using Simple.Expressions;

namespace Simple
{
    public interface IEnvironment
    {
        IExpression<T> GetValue<T>(string variableName);
        IEnvironment AddValue<T>(string variableName, IExpression<T> value);
    }
}

namespace Simple
{
    public interface IEnvironment
    {
        IExpression<T> GetValue<T>(string variableName);
    }
}

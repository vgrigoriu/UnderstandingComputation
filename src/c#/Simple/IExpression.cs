namespace Simple
{
    public interface IExpression<out T>
    {
        T Value { get; }
        bool IsReducible { get; }
        IExpression<T> Reduce(IEnvironment environment);
    }
}

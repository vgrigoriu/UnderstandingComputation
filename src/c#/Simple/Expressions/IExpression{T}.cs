namespace Simple.Expressions
{
    public interface IExpression<out T> : IReducible
    {
        T Value { get; }

        IExpression<T> Reduce(IEnvironment environment);
    }
}

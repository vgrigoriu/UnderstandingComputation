namespace Simple
{
    public interface IExpression<out T>
    {
        T Value { get; }
        IExpression<T> Evaluate(IEnvironment environment);

        IExpressionVisitor Accept(IExpressionVisitor visitor);
    }
}

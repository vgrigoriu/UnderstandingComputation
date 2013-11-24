namespace Simple
{
    public interface IExpression<T>
    {
        T Value { get; }
        IExpression<T> Evaluate(IEnvironment environment);

        IExpressionVisitor<T> Accept(IExpressionVisitor<T> visitor);
    }
}

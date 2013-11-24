namespace Simple
{
    public interface IExpression<T>
    {
        T Value { get; }

        IExpressionVisitor<T> Accept(IExpressionVisitor<T> visitor);
    }
}

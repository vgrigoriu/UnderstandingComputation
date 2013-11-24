namespace Simple
{
    public interface IExpression<T>
    {
        IExpressionVisitor<T> Accept(IExpressionVisitor<T> visitor);
    }
}

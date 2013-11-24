namespace Simple
{
    public interface IExpression<T>
    {
        void Accept(IExpressionVisitor<T> visitor);
    }
}

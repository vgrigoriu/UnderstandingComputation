namespace Simple
{
    public interface IExpressionVisitor<T>
    {
        IExpressionVisitor<T> Visit(PrimitiveExpression<T> primitiveExpression);

        IExpressionVisitor<T> Visit(BinaryExpression<T> binaryExpression);
        IExpressionVisitor<T> Visit(Variable<T> variable);
    }
}

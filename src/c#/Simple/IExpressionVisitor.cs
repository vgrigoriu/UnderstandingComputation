namespace Simple
{
    public interface IExpressionVisitor
    {
        IExpressionVisitor Visit<T>(PrimitiveExpression<T> primitiveExpression) where T : struct;

        IExpressionVisitor Visit<T>(BinaryExpression<T> binaryExpression);
        IExpressionVisitor Visit<T>(Variable<T> variable);
    }
}

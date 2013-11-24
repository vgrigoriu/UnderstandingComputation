namespace Simple
{
    public interface IExpressionVisitor<T>
    {
        void Visit(PrimitiveExpression<T> primitiveExpression);

        void Visit(BinaryExpression<T> binaryExpression);
        void Visit(Variable<T> variable);
    }
}

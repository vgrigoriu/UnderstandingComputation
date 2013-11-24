namespace Simple
{
    public interface IExpressionVisitor
    {
        IExpressionVisitor Visit<T>(PrimitiveExpression<T> primitiveExpression) where T : struct;

        IExpressionVisitor Visit(Add add);
        IExpressionVisitor Visit<T>(Variable<T> variable);
    }
}

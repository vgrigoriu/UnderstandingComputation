namespace Simple
{
    public interface IExpressionVisitor
    {
        IExpressionVisitor Accept<T>(PrimitiveExpression<T> primitiveExpression) where T : struct;

        IExpressionVisitor Accept(Add add);
        IExpressionVisitor Visit<T>(Variable<T> variable);
    }
}

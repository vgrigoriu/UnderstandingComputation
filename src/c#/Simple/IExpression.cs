namespace Simple
{
    public interface IExpression<T>
    {
        T Value { get; }
        bool IsReducible { get; }
        IExpression<T> Reduce();
    }
}

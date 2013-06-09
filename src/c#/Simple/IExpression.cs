namespace Simple
{
    public interface IExpression
    {
        int Value { get; }
        bool IsReducible { get; }
        IExpression Reduce();
    }
}

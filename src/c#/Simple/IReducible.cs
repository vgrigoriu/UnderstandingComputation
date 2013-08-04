namespace Simple
{
    public interface IReducible
    {
        bool IsReducible { get; }
    }

    public interface IStatement : IReducible
    {
        State Reduce(IEnvironment environment);
    }
}
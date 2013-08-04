namespace Simple
{
    public interface IStatement : IReducible
    {
        State Reduce(IEnvironment environment);
    }
}
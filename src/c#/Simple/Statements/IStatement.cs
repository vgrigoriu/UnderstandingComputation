namespace Simple.Statements
{
    public interface IStatement : IReducible
    {
        State Reduce(IEnvironment environment);
    }
}
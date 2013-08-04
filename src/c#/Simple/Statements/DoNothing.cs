using System;

namespace Simple.Statements
{
    public class DoNothing : IStatement
    {
        public bool IsReducible
        {
            get { return false; }
        }

        public State Reduce(IEnvironment environment)
        {
            throw new InvalidOperationException("DoNothing cannot be further reduced");
        }

        public override string ToString()
        {
            return "do-nothing";
        }
    }
}
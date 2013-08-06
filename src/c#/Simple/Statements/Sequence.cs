using System.Globalization;

namespace Simple.Statements
{
    public class Sequence : IStatement
    {
        private readonly IStatement first;
        private readonly IStatement second;

        public Sequence(IStatement first, IStatement second)
        {
            this.first = first;
            this.second = second;
        }

        public bool IsReducible
        {
            get { return true; }
        }

        public State Reduce(IEnvironment environment)
        {
            if (first.IsReducible)
            {
                var stateAfterFirstReduction = first.Reduce(environment);
                return new State(
                    new Sequence(stateAfterFirstReduction.Program, second),
                    stateAfterFirstReduction.Environment);
            }

            return new State(second, environment);
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}; {1}", first, second);
        }
    }
}

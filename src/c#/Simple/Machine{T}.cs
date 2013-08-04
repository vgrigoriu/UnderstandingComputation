using System;
using System.Globalization;
using Simple.Statements;

namespace Simple
{
    public class Machine
    {
        private IStatement statement;
        private IEnvironment environment;

        public IStatement Statement
        {
            get { return statement; }
        }

        public Machine(IStatement statement, IEnvironment environment)
        {
            this.statement = statement;
            this.environment = environment;
        }

        public void Run()
        {
            while (statement.IsReducible)
            {
                Console.WriteLine(this);
                Step();
            }

            Console.WriteLine(this);
        }

        private void Step()
        {
            var state = statement.Reduce(environment);
            statement = state.Program;
            environment = state.Environment;
        }

        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}, {1}",
                statement,
                environment);
        }
    }
}
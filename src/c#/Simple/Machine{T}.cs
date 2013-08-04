using System;
using System.Globalization;
using Simple.Statements;

namespace Simple
{
    public class Machine
    {
        public IStatement Statement { get; private set; }

        public IEnvironment Environment { get; private set; }

        public Machine(IStatement statement, IEnvironment environment)
        {
            Statement = statement;
            Environment = environment;
        }

        public void Run()
        {
            while (Statement.IsReducible)
            {
                Console.WriteLine(this);
                Step();
            }

            Console.WriteLine(this);
        }

        private void Step()
        {
            var state = Statement.Reduce(Environment);
            Statement = state.Program;
            Environment = state.Environment;
        }

        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}, {1}",
                Statement,
                Environment);
        }
    }
}
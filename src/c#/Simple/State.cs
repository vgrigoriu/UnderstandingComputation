namespace Simple
{
    public class State
    {
        private readonly IStatement program;
        private readonly IEnvironment environment;

        public State(IStatement program, IEnvironment environment)
        {
            this.program = program;
            this.environment = environment;
        }

        public IStatement Program
        {
            get { return program; }
        }

        public IEnvironment Environment
        {
            get { return environment; }
        }
    }
}

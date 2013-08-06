using Simple.Expressions;

namespace Simple.Statements
{
    public class If : IStatement
    {
        private readonly IExpression<bool> condition;
        private readonly IStatement consequence;
        private readonly IStatement alternative;

        public If(IExpression<bool> condition, IStatement consequence, IStatement alternative)
        {
            this.condition = condition;
            this.consequence = consequence;
            this.alternative = alternative;
        }

        public bool IsReducible
        {
            get { return true; }
        }

        public State Reduce(IEnvironment environment)
        {
            if (condition.IsReducible)
            {
                return new State(
                    new If(condition.Reduce(environment), consequence, alternative),
                    environment);
            }

            if (condition.Value)
            {
                return new State(consequence, environment);
            }

            return new State(alternative, environment);
        }
    }
}

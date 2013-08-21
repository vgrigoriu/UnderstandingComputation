using System.Globalization;
using Simple.Expressions;

namespace Simple.Statements
{
    public class While : IStatement
    {
        private readonly IExpression<bool> condition;
        private readonly IStatement body;

        public While(IExpression<bool> condition, IStatement body)
        {
            this.condition = condition;
            this.body = body;
        }

        public bool IsReducible
        {
            get { return true; }
        }

        public State Reduce(IEnvironment environment)
        {
            return new State(
                new If(condition, new Sequence(body, this), new DoNothing()), 
                environment);
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "while ({0}) {{ {1} }}", condition, body);
        }
    }
}

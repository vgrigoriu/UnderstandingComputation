using Simple.Expressions;

namespace Simple.Statements
{
    /// <summary>
    /// Statement that represents a strongly-typed assignment
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Assign<T> : IStatement
    {
        private readonly Variable<T> variable;
        private readonly IExpression<T> expression;

        public bool IsReducible
        {
            get { return true; }
        }

        public Assign(Variable<T> variable, IExpression<T> expression)
        {
            this.variable = variable;
            this.expression = expression;
        }

        public State Reduce(IEnvironment environment)
        {
            if (expression.IsReducible)
                return new State(
                    new Assign<T>(variable, expression.Reduce(environment)),
                    environment);

            return new State(
                new DoNothing(),
                environment.AddValue(variable.Name, expression));
        }
    }
}

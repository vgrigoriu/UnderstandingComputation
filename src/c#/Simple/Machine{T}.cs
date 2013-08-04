using System;
using Simple.Expressions;

namespace Simple
{
    public class Machine<T>
    {
        private IExpression<T> expression;
        private readonly IEnvironment environment;

        public IExpression<T> Expression
        {
            get { return expression; }
        }

        internal Machine(IExpression<T> expression, IEnvironment environment)
        {
            this.expression = expression;
            this.environment = environment;
        }

        public void Run()
        {
            while (expression.IsReducible)
            {
                Console.WriteLine(expression);
                Step();
            }

            Console.WriteLine(expression);
        }

        private void Step()
        {
            expression = expression.Reduce(environment);
        }
    }
}
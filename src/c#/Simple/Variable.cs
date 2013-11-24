using System;

namespace Simple
{
    public class Variable<T>: IExpression<T>
    {
        private readonly string name;

        public T Value
        {
            get { throw new System.NotImplementedException(); }
        }

        public IExpression<T> Evaluate(IEnvironment environment)
        {
            return environment.GetValue<T>(name);
        }

        public IExpressionVisitor<T> Accept(IExpressionVisitor<T> visitor)
        {
            if (visitor == null) throw new ArgumentNullException("visitor");

            return visitor.Visit(this);
        }

        public Variable(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }
}

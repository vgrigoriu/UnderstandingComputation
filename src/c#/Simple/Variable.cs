using System;

namespace Simple
{
    public class Variable<T>: IExpression<T>
    {
        private readonly string name;

        public IExpression<T> Evaluate(IEnvironment environment)
        {
            return environment.GetValue<T>(name);
        }

        public void Accept(IExpressionVisitor<T> visitor)
        {
            if (visitor == null) throw new ArgumentNullException("visitor");

            visitor.Visit(this);
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

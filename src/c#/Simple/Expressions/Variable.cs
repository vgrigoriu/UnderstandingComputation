using System;

namespace Simple.Expressions
{
    public class Variable<T> : IExpression<T>
    {
        private readonly string name;

        public Variable(string name)
        {
            this.name = name;
        }

        public T Value
        {
            get { throw new InvalidOperationException("Variables need to be reduced to get their value"); }
        }

        public bool IsReducible
        {
            get { return true; }
        }

        public string Name
        {
            get { return name; }
        }

        public IExpression<T> Reduce(IEnvironment environment)
        {
            return environment.GetValue<T>(Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

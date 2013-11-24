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

        public IExpressionVisitor Accept(IExpressionVisitor visitor)
        {
            throw new System.NotImplementedException();
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

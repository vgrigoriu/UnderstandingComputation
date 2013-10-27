namespace Simple
{
    public class Variable<T>: IExpression<T>
    {
        private string name;

        public T Value
        {
            get { throw new System.NotImplementedException(); }
        }

        public IExpression<T> Evaluate(IEnvironment environment)
        {
            return environment.GetValue<T>(name);
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

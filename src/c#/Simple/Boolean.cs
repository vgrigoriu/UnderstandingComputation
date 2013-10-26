namespace Simple
{
    public class Boolean: IExpression<bool>
    {
        private readonly bool value;

        public bool Value
        {
            get { return value; }
        }

        public IExpression<bool> Evaluate(IEnvironment environment)
        {
            return this;
        }

        public Boolean(bool value)
        {
            this.value = value;
        }
    }
}

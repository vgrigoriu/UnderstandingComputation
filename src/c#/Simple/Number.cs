namespace Simple
{
    public class Number: IExpression<int>
    {
        private readonly int value;

        public int Value
        {
            get { return value; }
        }

        public IExpression<int> Evaluate(IEnvironment environment)
        {
            return this;
        }

        public Number(int value)
        {
            this.value = value;
        }
    }
}

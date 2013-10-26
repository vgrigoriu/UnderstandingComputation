namespace Simple
{
    public class PrimitiveExpression<T>: IExpression<T>
    {
        private readonly T value;

        public T Value
        {
            get { return value; }
        }

        public IExpression<T> Evaluate(IEnvironment environment)
        {
            return this;
        }

        public PrimitiveExpression(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}

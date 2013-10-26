namespace Simple
{
    public abstract class PrimitiveExpression<T>: IExpression<T>
        where T: struct
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

        protected PrimitiveExpression(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}

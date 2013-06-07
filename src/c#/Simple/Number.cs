namespace Simple
{
    public class Number : IExpression
    {
        private readonly int value;

        public int Value { get { return value; } }

        public Number(int value)
        {
            this.value = value;
        }
    }
}

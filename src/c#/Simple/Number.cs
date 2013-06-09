using System.Globalization;

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

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }

        public bool IsReducible
        {
            get { return false; }
        }
    }
}

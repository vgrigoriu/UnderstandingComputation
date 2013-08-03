using System;
using System.Globalization;

namespace Simple
{
    public class Number : IExpression<int>
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

        public IExpression<int> Reduce(IEnvironment environment)
        {
            throw new InvalidOperationException("Numbers can't be reduced");
        }
    }
}

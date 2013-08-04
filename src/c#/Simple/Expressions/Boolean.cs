using System;
using System.Globalization;

namespace Simple.Expressions
{
    public class Boolean : IExpression<bool>
    {
        private readonly bool value;

        public bool Value { get { return value; } }

        public bool IsReducible { get { return false; } }

        public Boolean(bool value)
        {
            this.value = value;
        }

        public IExpression<bool> Reduce(IEnvironment environment)
        {
            throw new InvalidOperationException("Boolean values can't be reduced");
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}

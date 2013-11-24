using System;

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

        public IExpressionVisitor Accept(IExpressionVisitor visitor)
        {
            if (visitor == null) throw new ArgumentNullException("visitor");

            return visitor.Visit(this);
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

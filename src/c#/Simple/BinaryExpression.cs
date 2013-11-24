using System;

namespace Simple
{
    public abstract class BinaryExpression<T>: IExpression<T>
    {
        private readonly IExpression<T> firstOperand;
        private readonly IExpression<T> secondOperand;

        public T Value
        {
            get { throw new NotImplementedException(); }
        }

        public IExpression<T> FirstOperand
        {
            get { return firstOperand; }
        }

        public IExpression<T> SecondOperand
        {
            get { return secondOperand; }
        }

        protected BinaryExpression(IExpression<T> firstOperand, IExpression<T> secondOperand)
        {
            this.firstOperand = firstOperand;
            this.secondOperand = secondOperand;
        }

        public abstract string OperandName { get; }

        public abstract Func<T, T, T> Operand { get; }

        public IExpressionVisitor<T> Accept(IExpressionVisitor<T> visitor)
        {
            if (visitor == null) throw new ArgumentNullException("visitor");

            return visitor.Visit(this);
        }
    }
}
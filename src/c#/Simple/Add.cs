using System;

namespace Simple
{
    public class Add: IExpression<int>
    {
        private readonly IExpression<int> firstOperand;
        private readonly IExpression<int> secondOperand;

        public Add(IExpression<int> firstOperand, IExpression<int> secondOperand)
        {
            this.firstOperand = firstOperand;
            this.secondOperand = secondOperand;
        }

        public int Value
        {
            get { throw new System.NotImplementedException(); }
        }

        public IExpression<int> FirstOperand
        {
            get { return firstOperand; }
        }

        public IExpression<int> SecondOperand
        {
            get { return secondOperand; }
        }

        public IExpression<int> Evaluate(IEnvironment environment)
        {
            var firstOperandValue = firstOperand.Evaluate(environment);
            var secondOperandValue = secondOperand.Evaluate(environment);
            return new Number(firstOperandValue.Value + secondOperandValue.Value);
        }

        public IExpressionVisitor Accept(IExpressionVisitor visitor)
        {
            if (visitor == null) throw new ArgumentNullException("visitor");

            return visitor.Accept(this);
        }
    }
}

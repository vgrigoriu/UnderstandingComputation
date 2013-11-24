using System;

namespace Simple
{
    public class Add: BinaryExpression<int>
    {
        public Add(IExpression<int> firstOperand, IExpression<int> secondOperand)
            : base(firstOperand, secondOperand)
        {
        }

        public override IExpression<int> Evaluate(IEnvironment environment)
        {
            var firstOperandValue = FirstOperand.Evaluate(environment);
            var secondOperandValue = SecondOperand.Evaluate(environment);
            return new Number(firstOperandValue.Value + secondOperandValue.Value);
        }

        public override string OperandName
        {
            get { return "+"; }
        }

        public override Func<int, int, int> Operand
        {
            get { return (op1, op2) => op1 + op2; }
        }
    }
}

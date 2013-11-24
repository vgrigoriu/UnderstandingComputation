using System;

namespace Simple
{
    public class ExpressionEvaluator<T>: IExpressionVisitor<T>
    {
        private T value;

        public IExpressionVisitor<T> Visit(PrimitiveExpression<T> primitiveExpression)
        {
            value = primitiveExpression.Value;

            return this;
        }

        public IExpressionVisitor<T> Visit(BinaryExpression<T> binaryExpression)
        {
            binaryExpression.FirstOperand.Accept(this);
            var firstValue = value;

            binaryExpression.SecondOperand.Accept(this);
            var secondValue = value;

            value = binaryExpression.Operand(firstValue, secondValue);

            return this;
        }

        public IExpressionVisitor<T> Visit(Variable<T> variable)
        {
            throw new NotImplementedException();
        }

        public T Value
        {
            get { return value; }
        }
    }
}

using System.Globalization;
using System.Text;

namespace Simple
{
    public class ExpressionStringifier<T> : IExpressionVisitor<T>
    {
        private readonly StringBuilder output = new StringBuilder();

        public string Output
        {
            get
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "«{0}»",
                    output);
            }
        }

        public void Visit(PrimitiveExpression<T> primitiveExpression)
        {
            output.AppendFormat(CultureInfo.InvariantCulture, "{0}", primitiveExpression.Value);
        }

        public void Visit(BinaryExpression<T> binaryExpression)
        {
            binaryExpression.FirstOperand.Accept(this);
            output.AppendFormat(" {0} ", binaryExpression.OperandName);
            binaryExpression.SecondOperand.Accept(this);
        }

        public void Visit(Variable<T> variable)
        {
            output.Append(variable.Name);
        }
    }
}

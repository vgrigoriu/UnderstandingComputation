using System.Globalization;
using System.Text;

namespace Simple
{
    public class ExpressionStringifier : IExpressionVisitor
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

        public IExpressionVisitor Visit<T>(PrimitiveExpression<T> primitiveExpression) where T : struct
        {
            output.AppendFormat(CultureInfo.InvariantCulture, "{0}", primitiveExpression.Value);
            return this;
        }

        public IExpressionVisitor Visit(Add add)
        {
            add.FirstOperand.Accept(this);
            output.Append(" + ");
            add.SecondOperand.Accept(this);

            return this;
        }

        public IExpressionVisitor Visit<T>(Variable<T> variable)
        {
            output.Append(variable.Name);

            return this;
        }
    }
}

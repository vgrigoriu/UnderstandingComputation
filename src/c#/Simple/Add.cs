using System.Globalization;

namespace Simple
{
    public class Add : IExpression
    {
        private readonly IExpression left;

        private readonly IExpression right;

        public IExpression Left
        {
            get { return left; }
        }

        public IExpression Right
        {
            get { return right; }
        }

        public Add(IExpression left, IExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0} + {1}",
                Left,
                Right);
        }

        public bool IsReducible
        {
            get { return true; }
        }
    }
}

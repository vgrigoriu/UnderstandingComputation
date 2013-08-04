using System;
using System.Globalization;

namespace Simple.Expressions
{
    public class Add : IExpression<int>
    {
        private readonly IExpression<int> left;

        private readonly IExpression<int> right;

        public IExpression<int> Left
        {
            get { return left; }
        }

        public IExpression<int> Right
        {
            get { return right; }
        }

        public Add(IExpression<int> left, IExpression<int> right)
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


        public IExpression<int> Reduce(IEnvironment environment)
        {
            if (left.IsReducible)
                return new Add(left.Reduce(environment), right);
            if (right.IsReducible)
                return new Add(left, right.Reduce(environment));

            return new Number(left.Value + right.Value);
        }

        public int Value
        {
            get { throw new InvalidOperationException("Add needs to be reduces before the value can be obtained"); }
        }
    }
}

﻿using System;
using System.Globalization;

namespace Simple.Expressions
{
    public class LessThan : IExpression<bool>
    {
        private readonly IExpression<int> left;
        private readonly IExpression<int> right;

        public bool Value
        {
            get { throw new InvalidOperationException("Comparisons (<) need to be reduced before the value can be obtained"); }
        }

        public bool IsReducible
        {
            get { return true; }
        }

        public LessThan(IExpression<int> left, IExpression<int> right)
        {
            this.left = left;
            this.right = right;
        }

        public IExpression<bool> Reduce(IEnvironment environment)
        {
            if (left.IsReducible)
            {
                return new LessThan(left.Reduce(environment), right);
            }

            if (right.IsReducible)
            {
                return new LessThan(left, right.Reduce(environment));
            }

            return new Boolean(left.Value < right.Value);
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0} < {1}", left, right);
        }
    }
}

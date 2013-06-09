﻿using System;
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


        public IExpression Reduce()
        {
            if (left.IsReducible)
                return new Add(left.Reduce(), right);
            if (right.IsReducible)
                return new Add(left, right.Reduce());

            return new Number(left.Value + right.Value);
        }

        public int Value
        {
            get { throw new InvalidOperationException("Add needs to be reduces before the value can be obtained"); }
        }
    }
}

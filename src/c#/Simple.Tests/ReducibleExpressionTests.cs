using FluentAssertions;
using System;
using Xunit;

namespace Simple.Tests
{
    public class ReducibleExpressionTests
    {
        private const IEnvironment NullEnvironment = null;

        [Fact]
        public void GivenANumber_ThenItIsNotReducible()
        {
            var number = new Number(12321);

            number.IsReducible.Should().BeFalse();
        }

        [Fact]
        public void GivenANumber_ThenReduceThrowsException()
        {
            var number = new Number(112);

            Action action = () => number.Reduce(NullEnvironment);
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void GivenAnAdd_WhenLeftIsReducible_ThenReduceReducesLeft()
        {
            var add = new Add(new Reducible(true, false), new Reducible(true, false));
            var reducedAdd = add.Reduce(NullEnvironment) as Add;

            var left = reducedAdd.Left as Reducible;
            var right = reducedAdd.Right as Reducible;

            left.IsReduced.Should().BeTrue();
            right.IsReduced.Should().BeFalse();
        }

        [Fact]
        public void GivenAnAdd_WhenLeftIsNotReducible_ThenReduceReducesRight()
        {
            var add = new Add(new Reducible(false, false), new Reducible(true, false));
            var reducedAdd = add.Reduce(NullEnvironment) as Add;

            var left = reducedAdd.Left as Reducible;
            var right = reducedAdd.Right as Reducible;

            left.IsReduced.Should().BeFalse();
            right.IsReduced.Should().BeTrue();
        }

        [Fact]
        public void GivenAnAdd_WhenNoTermIsReducible_ThenReduceAddsTheValues()
        {
            var add = new Add(new Number(77), new Number(5));

            var reducedAdd = add.Reduce(NullEnvironment);

            reducedAdd.Value.Should().Be(82);
        }

        private class Reducible : IExpression<int>
        {
            private readonly bool isReducible;
            private readonly bool isReduced;

            public Reducible(bool isReducible, bool isReduced)
            {
                this.isReducible = isReducible;
                this.isReduced = isReduced;
            }

            public bool IsReduced
            {
                get { return isReduced; }
            }

            public bool IsReducible
            {
                get { return isReducible; }
            }

            public IExpression<int> Reduce(IEnvironment environment)
            {
                return new Reducible(this.isReducible, true);
            }

            public int Value
            {
                get { throw new NotImplementedException(); }
            }
        }
    }
}

using FluentAssertions;
using Simple.Expressions;
using Xunit;

namespace Simple.Tests
{
    public class ExpressionInspectTests
    {
        [Fact]
        public void GivenANumber_WhenInspectIsCalled_ThenTheValueIsReturnedInQuotes()
        {
            var number = new Number(7);
            number.Inspect().Should().Be("«7»");
        }

        [Fact]
        public void GivenAnAddExpression_WhenInspectIsCalled_ThenTheOperandsAreReturnedInQuotes()
        {
            var add = new Add(new Number(13), new Number(8));

            add.Inspect().Should().Be("«13 + 8»");
        }

        [Fact]
        public void GivenAMultiplyExpression_WhenInspectIsCalled_ThenTheOperandsAreReturnedInQuotes()
        {
            var multiply = new Multiply(new Number(2), new Number(14));

            multiply.Inspect().Should().Be("«2 * 14»");
        }

        [Fact]
        public void GivenAComplexExpression_WhenInspectIsCalled_ThenTheRepresentationIsReturnedInQuotes()
        {
            var expression = new Add(
                new Multiply(new Number(1), new Number(2)),
                new Multiply(new Number(3), new Number(4)));

            expression.Inspect().Should().Be("«1 * 2 + 3 * 4»");
        }
    }
}

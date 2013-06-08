using FluentAssertions;
using Xunit;

namespace Simple.Tests
{
    public class ExpressionInspectTests
    {
        [Fact]
        public void GivenANumber_WhenInspectIsCalled_ThenTheValueInQuotesIsReturned()
        {
            var number = new Number(7);
            number.Inspect().Should().Be("«7»");
        }
    }
}

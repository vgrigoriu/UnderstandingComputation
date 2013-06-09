using FluentAssertions;
using Xunit;

namespace Simple.Tests
{
    public class ReducibleExpressionTests
    {
        [Fact]
        public void GivenANumber_ThenItIsNotReducible()
        {
            var number = new Number(12321);

            number.IsReducible.Should().BeFalse();
        }
    }
}

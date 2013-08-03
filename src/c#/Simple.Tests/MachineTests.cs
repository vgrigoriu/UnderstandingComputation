using FluentAssertions;
using Xunit;

namespace Simple.Tests
{
    public class MachineTests
    {
        [Fact]
        public void GivenAReducibleExpression_WhenRunIsCalled_TheExpressionIsReduced()
        {
            var e = new Add(
                new Multiply(new Number(1), new Number(2)),
                new Multiply(new Number(3), new Number(4)));

            var machine = Machine.ForExpression(e);

            machine.Run();

            machine.Expression.IsReducible.Should().BeFalse();
        }
    }
}

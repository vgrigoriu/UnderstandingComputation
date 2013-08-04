using FluentAssertions;
using Simple.Expressions;
using Xunit;

namespace Simple.Tests
{
    public class VariableTests
    {
        [Fact]
        public void GivenAnEnvironment_WhenAnExpressionWithVariablesIsReduces_TheCorrectValueIsReturned()
        {
            var environment = Environment.Empty;
            environment = environment.AddValue("x", new Number(3));
            environment = environment.AddValue("y", new Number(4));

            var expression = new Add(
                new Variable<int>("x"),
                new Variable<int>("y"));

            var machine = Machine.ForExpression(expression, environment);

            machine.Run();

            machine.Expression.Should().BeOfType<Number>();
            machine.Expression.Value.Should().Be(7);
        }
    }
}

using FluentAssertions;
using Simple.Expressions;
using Simple.Statements;
using Xunit;

namespace Simple.Tests
{
    public class AssignmentTests
    {
        [Fact]
        public void GivenAnAssignmentWithReducibleExpression_WhenReduceIsCalled_ThenTheExpressionIsReduced()
        {
            var environment = Environment.Empty;
            var assignment =
                new Assign<int>(
                    new Variable<int>("x"),
                    new Add(
                        new Number(1),
                        new Number(2)));

            var state = assignment.Reduce(environment);

            state.Environment.Should().BeSameAs(environment);

            var newAssignment = (Assign<int>)state.Program;

            newAssignment.Expression.IsReducible.Should().BeFalse();
        }

        [Fact]
        public void GivenAnAssignmentWithIreducibleExpression_WhenReduceIsCalled_ThenTheEnvironmentIsChanged()
        {
            var environment = Environment.Empty;
            var assignment =
                new Assign<int>(
                    new Variable<int>("x"),
                    new Number(9));

            var state = assignment.Reduce(environment);

            var value = state.Environment.GetValue<int>("x");

            value.Value.Should().Be(9);
        }
    }
}

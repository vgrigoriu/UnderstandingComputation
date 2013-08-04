using FluentAssertions;
using Simple.Expressions;
using Simple.Statements;
using Xunit;

namespace Simple.Tests
{
    public class MachineTests
    {
        [Fact]
        public void GivenAReducibleStatement_WhenRunIsCalled_TheStatementIsReduced()
        {
            var environment = Environment.Empty;

            var statement = new Assign<int>(
                new Variable<int>("q"),
                new Number(1));

            var machine = new Machine(statement, environment);

            machine.Run();

            machine.Statement.IsReducible.Should().BeFalse();
        }

        [Fact]
        public void GivenAComplexStatement_WhenTheMachineIsRun_TheStatementIsExecuted()
        {
            var environment = Environment.Empty;
            environment = environment.AddValue("x", new Number(3));
            environment = environment.AddValue("y", new Number(4));

            // x = x + y
            var statement = new Assign<int>(
                new Variable<int>("x"),
                new Add(
                    new Variable<int>("x"),
                    new Variable<int>("y")));

            var machine = new Machine(statement, environment);

            machine.Run();

            machine.Environment.GetValue<int>("x").Value.Should().Be(7);
        }
    }
}

using FluentAssertions;
using Simple.Expressions;
using Simple.Statements;
using Xunit;

namespace Simple.Tests
{
    public class WhileTests
    {
        [Fact]
        public void GivenFalseCondition_WhenWhileIsEvaluated_NothingHappens()
        {
            var whileStatement = CreateWhileStatement();

            var environment = Environment.Empty;
            environment = environment.AddValue("x", new Number(7));

            var machine = new Machine(whileStatement, environment);
            machine.Run();

            var finalEnvironment = machine.Environment;
            finalEnvironment.GetValue<int>("x").Value.Should().Be(7, "because the condition was false so the body was never executed");
        }

        [Fact]
        public void GivenInitiallyTrueCondition_WhenWhileIsEvaluated_BodyIsEvaluatedUntilConditionBecomesFalse()
        {
            var whileStatement = CreateWhileStatement();

            var environment = Environment.Empty;
            environment = environment.AddValue("x", new Number(1));

            var machine = new Machine(whileStatement, environment);
            machine.Run();

            var finalEnvironment = machine.Environment;
            finalEnvironment.GetValue<int>("x").Value.Should().Be(8, "because the body was executed three times");
        }

        private static IStatement CreateWhileStatement()
        {
            // while (x < 5) { x = x + x }
            var condition = new LessThan(new Variable<int>("x"), new Number(5));
            var body = new Assign<int>(
                new Variable<int>("x"),
                new Add(new Variable<int>("x"), new Variable<int>("x")));

            var whileStatement = new While(condition, body);
            return whileStatement;
        }
    }
}

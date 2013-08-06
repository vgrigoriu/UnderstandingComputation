using FluentAssertions;
using Simple.Expressions;
using Simple.Statements;
using Xunit;

namespace Simple.Tests
{
    public class IfTests
    {
        [Fact]
        public void GivenAnIfStatement_WhenConditionIsTrue_ThenConsequenceIsExecuted()
        {
            var ifStatement = CreateIfStatement();

            var environment = CreateBaseEnvironment();
            environment = environment.AddValue("x", new Number(-1));

            var machine = new Machine(ifStatement, environment);
            machine.Run();

            var finalEnvironment = machine.Environment;
            finalEnvironment.GetValue<int>("a").Value.Should().Be(1, "because the consequence was executed");
            finalEnvironment.GetValue<int>("b").Value.Should().Be(0, "because the alternative was not executed");
        }

        [Fact]
        public void GivenAnIfStatement_WhenConditionIsFalse_ThenAlternativeIsExecuted()
        {
            var ifStatement = CreateIfStatement();

            var environment = CreateBaseEnvironment();
            environment = environment.AddValue("x", new Number(1));

            var machine = new Machine(ifStatement, environment);
            machine.Run();

            var finalEnvironment = machine.Environment;
            finalEnvironment.GetValue<int>("a").Value.Should().Be(0, "because the consequence was not executed");
            finalEnvironment.GetValue<int>("b").Value.Should().Be(1, "because the alternative was executed");
        }

        private static IEnvironment CreateBaseEnvironment()
        {
            var environment = Environment.Empty;
            environment = environment.AddValue("a", new Number(0));
            environment = environment.AddValue("b", new Number(0));
            return environment;
        }

        private static IStatement CreateIfStatement()
        {
            var condition = new LessThan(new Variable<int>("x"), new Number(0));
            var consequence = new Assign<int>(new Variable<int>("a"), new Number(1));
            var alternative = new Assign<int>(new Variable<int>("b"), new Number(1));

            var ifStatement = new If(condition, consequence, alternative);
            return ifStatement;
        }
    }
}

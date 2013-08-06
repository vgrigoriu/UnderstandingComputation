using FluentAssertions;
using Simple.Expressions;
using Simple.Statements;
using Xunit;

namespace Simple.Tests
{
    public class SequenceTests
    {
        [Fact]
        public void GivenASequence_WhenItIsRun_BothStatementsAreExecuted()
        {
            var first = new Assign<int>(new Variable<int>("x"), new Add(new Number(1), new Number(2)));
            var second = new Assign<int>(new Variable<int>("y"), new Add(new Number(3), new Number(4)));

            var sequence = new Sequence(first, second);

            var machine = new Machine(sequence, Environment.Empty);
            machine.Run();
            var finalEnvironment = machine.Environment;

            finalEnvironment.GetValue<int>("x").Value.Should().Be(3, "the first statement was executed");
            finalEnvironment.GetValue<int>("y").Value.Should().Be(7, "the second statement was executed");
        }
    }
}

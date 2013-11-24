using Moq;

using Xunit;

namespace Simple.Tests
{
    public class ExpressionEvaluatorTests
    {
        private static readonly IEnvironment NullEnvironment = null;

        [Fact]
        public void CanEvaluateNumber()
        {
            var number = new Number(-123);
            var sut = new ExpressionEvaluator<int>(NullEnvironment);

            number.Accept(sut);

            Assert.Equal(-123, sut.Value);
        }

        [Fact]
        public void CanEvaluateAdditionOfTwoNumbers()
        {
            var firstNumber = new Number(11);
            var secondNumber = new Number(99);
            var addition = new Add(firstNumber, secondNumber);
            var sut = new ExpressionEvaluator<int>(NullEnvironment);

            addition.Accept(sut);

            Assert.Equal(110, sut.Value);
        }

        [Fact]
        public void CanEvaluateAVariable()
        {
            var variable = new Variable<int>("height");
            var number = new Number(1122);
            var enviroment = new Mock<IEnvironment>();
            enviroment.Setup(env => env.GetValue<int>("height")).Returns(number);

            var sut = new ExpressionEvaluator<int>(enviroment.Object);

            variable.Accept(sut);

            Assert.Equal(number.Value, sut.Value);
        }

        [Fact]
        public void CanEvaluateAdditionOfVariableAndNumber()
        {
            var variable = new Variable<int>("i");
            var variableValue = new Number(75);
            var otherNumber = new Number(6);
            var addition = new Add(variable, otherNumber);

            var enviroment = new Mock<IEnvironment>();
            enviroment.Setup(env => env.GetValue<int>("i")).Returns(variableValue);

            var sut = new ExpressionEvaluator<int>(enviroment.Object);

            addition.Accept(sut);

            Assert.Equal(81, sut.Value);
        }
    }
}

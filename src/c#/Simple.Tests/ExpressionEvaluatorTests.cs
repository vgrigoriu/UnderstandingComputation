using Xunit;

namespace Simple.Tests
{
    public class ExpressionEvaluatorTests
    {
        [Fact]
        public void CanEvaluateNumber()
        {
            var number = new Number(-123);
            var sut = new ExpressionEvaluator<int>();

            number.Accept(sut);

            Assert.Equal(-123, sut.Value);
        }

        [Fact]
        public void CanEvaluateAdditionOfTwoNumbers()
        {
            var firstNumber = new Number(11);
            var secondNumber = new Number(99);
            var addition = new Add(firstNumber, secondNumber);
            var sut = new ExpressionEvaluator<int>();

            addition.Accept(sut);

            Assert.Equal(110, sut.Value);
        }
    }
}

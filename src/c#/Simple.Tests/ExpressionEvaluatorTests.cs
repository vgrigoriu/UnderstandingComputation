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
    }
}

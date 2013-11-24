using Xunit;

namespace Simple.Tests
{
    public class ExpressionStringifierTests
    {
        [Fact]
        public void CanStringifyANumber()
        {
            var number = new Number(18);
            var sut = new ExpressionStringifier();

            number.Accept(sut);

            Assert.Equal("«18»", sut.Output);
        }
    }
}

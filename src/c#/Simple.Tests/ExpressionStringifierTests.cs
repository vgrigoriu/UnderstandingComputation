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

        [Fact]
        public void CanStringifyABoolean()
        {
            var boolean = new Boolean(true);
            var sut = new ExpressionStringifier();

            boolean.Accept(sut);

            Assert.Equal("«True»", sut.Output);
        }

        [Fact]
        public void CanStringifyAnAddExpressionOfTwoNumbers()
        {
            var add = new Add(new Number(12), new Number(101));
            var sut = new ExpressionStringifier();

            add.Accept(sut);

            Assert.Equal("«12 + 101»", sut.Output);
        }

        [Fact]
        public void CanStringifyAnAddExpressionOfOneVariableAndOneNumber()
        {
            var add = new Add(new Variable<int>("i"), new Number(3));
            var sut = new ExpressionStringifier();

            add.Accept(sut);

            Assert.Equal("«i + 3»", sut.Output);
        }

        [Fact]
        public void CanStringifyAVariable()
        {
            var variable = new Variable<int>("weight");
            var sut = new ExpressionStringifier();

            variable.Accept(sut);

            Assert.Equal("«weight»", sut.Output);
        }
    }
}

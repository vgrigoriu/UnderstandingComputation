﻿using Xunit;

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
    }
}

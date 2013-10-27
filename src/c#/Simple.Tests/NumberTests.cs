using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace Simple.Tests
{
    public class NumberTests
    {
        [Theory, AutoData]
        public void NumberEvaluatesToSelf(Number number)
        {
            var result = number.Evaluate(null);

            Assert.Same(number, result);
        }

        [Theory, AutoData]
        public void NumberValueIsTheOnePassedInConstructor(int value)
        {
            var sut = new Number(value);

            Assert.Equal(value, sut.Value);
        }
    }
}

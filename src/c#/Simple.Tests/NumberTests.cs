using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace Simple.Tests
{
    public class NumberTests
    {
        [Theory, AutoData]
        public void NumberValueIsTheOnePassedInConstructor(int value)
        {
            var sut = new Number(value);

            Assert.Equal(value, sut.Value);
        }
    }
}

using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace Simple.Tests
{
    public class BooleanTests
    {
        [Theory, AutoData]
        public void BooleanEvaluatesToSelf(Boolean boolean)
        {
            var result = boolean.Evaluate(null);

            Assert.Same(boolean, result);
        }

        [Theory, AutoData]
        public void BooleanValueIsTheOnePassedInConstructor(bool value)
        {
            var sut = new Boolean(value);

            Assert.Equal(value, sut.Value);
        }
    }
}

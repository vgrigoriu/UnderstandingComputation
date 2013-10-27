using Xunit;

namespace Simple.Tests
{
    public class BooleanTests
    {
        [Fact]
        public void BooleanEvaluatesToSelf()
        {
            var sut = new Boolean(false);
            var result = sut.Evaluate(null);

            Assert.Same(sut, result);
        }

        [Fact]
        public void BooleanValueIsTheOnePassedInConstructor()
        {
            var value = true;
            var sut = new Boolean(value);

            Assert.Equal(value, sut.Value);
        }
    }
}

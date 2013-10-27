using Ploeh.AutoFixture;
using Xunit;

namespace Simple.Tests
{
    public class NumberTests
    {
        private Fixture fixture;

        public NumberTests()
        {
            fixture = new Fixture();
        }

        [Fact]
        public void NumberEvaluatesToSelf()
        {
            var sut = fixture.Create<Number>();
            var result = sut.Evaluate(null);

            Assert.Same(sut, result);
        }

        [Fact]
        public void NumberValueIsTheOnePassedInConstructor()
        {
            var value = fixture.Create<int>();
            var sut = new Number(value);

            Assert.Equal(value, sut.Value);
        }
    }
}

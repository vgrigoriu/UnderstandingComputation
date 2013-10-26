using NUnit.Framework;

namespace Simple.Tests
{
    [TestFixture]
    public class BooleanTests
    {
        [Test]
        public void BooleanEvaluatesToSelf()
        {
            var sut = new Boolean(false);
            var result = sut.Evaluate(null);

            Assert.That(result, Is.SameAs(sut));
        }

        [Test]
        public void BooleanValueIsTheOnePassedInConstructor()
        {
            var value = true;
            var sut = new Boolean(value);

            Assert.That(sut.Value, Is.EqualTo(value));
        }
    }
}

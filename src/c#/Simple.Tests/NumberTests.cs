using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Simple.Tests
{
    [TestFixture]
    public class NumberTests
    {
        private Fixture fixture;

        [SetUp]
        public void CreateFixture()
        {
            fixture = new Fixture();
        }

        [Test]
        public void NumberEvaluatesToSelf()
        {
            var sut = new Number(0);
            var result = sut.Evaluate(null);

            Assert.That(result, Is.SameAs(sut));
        }

        [Test]
        public void NumberValueIsTheOnePassedInConstructor()
        {
            var value = fixture.Create<int>();
            var sut = new Number(value);

            Assert.That(sut.Value, Is.EqualTo(value));
        }
    }
}

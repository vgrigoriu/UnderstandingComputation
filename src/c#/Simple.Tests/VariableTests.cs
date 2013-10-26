using Moq;
using NUnit.Framework;

namespace Simple.Tests
{
    [TestFixture]
    public class VariableTests
    {
        [Test]
        public void VariableGetsValueFromEnvironment()
        {
            var enviroment = new Mock<IEnvironment>();
            var variableName = "count";
            var number = new Number(6);
            enviroment.SetupGet(env => env[variableName]).Returns(number);

            var sut = new Variable<int>(variableName);

            var result = sut.Evaluate(enviroment.Object);

            Assert.That(result, Is.SameAs(number));
        }
    }
}

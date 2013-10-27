using Moq;
using Xunit;

namespace Simple.Tests
{
    public class VariableTests
    {
        [Fact]
        public void VariableGetsValueFromEnvironment()
        {
            var enviroment = new Mock<IEnvironment>();
            var variableName = "count";
            var number = new Number(6);
            enviroment.SetupGet(env => env[variableName]).Returns(number);

            var sut = new Variable<int>(variableName);

            var result = sut.Evaluate(enviroment.Object);

            Assert.Same(number, result);
        }
    }
}

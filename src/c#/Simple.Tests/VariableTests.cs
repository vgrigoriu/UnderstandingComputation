using Moq;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

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
            enviroment.Setup(env => env.GetValue<int>(variableName)).Returns(number);

            var sut = new Variable<int>(variableName);

            var result = sut.Evaluate(enviroment.Object);

            Assert.Same(number, result);
        }

        [Theory, AutoData]
        public void CanGetVariableName(string variableName)
        {
            var sut = new Variable<string>(variableName);

            Assert.Equal(variableName, sut.Name);
        }
    }
}

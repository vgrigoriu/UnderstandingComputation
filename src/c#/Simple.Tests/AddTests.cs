using Moq;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace Simple.Tests
{
    public class AddTests
    {
        [Theory, AutoData]
        public void AddAddsSimpleOperands(Number firstOperand, Number secondOperand)
        {
            var sut = new Add(firstOperand, secondOperand);

            System.Console.WriteLine("{0} + {1}", firstOperand, secondOperand);

            var result = sut.Evaluate(null);


            Assert.Equal(firstOperand.Value + secondOperand.Value, result.Value);
        }

        [Theory, AutoData]
        public void AddAddsVariablesAndNumbers(Number number, Variable<int> variable, Number variableValue)
        {
            var enviroment = new Mock<IEnvironment>();
            enviroment.Setup(env => env.GetValue<int>(variable.Name)).Returns(variableValue);

            var sut = new Add(number, variable);
            var result = sut.Evaluate(enviroment.Object);

            Assert.Equal(number.Value + variableValue.Value, result.Value);
        }
    }
}

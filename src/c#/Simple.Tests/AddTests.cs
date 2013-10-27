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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Simple.Tests
{
    [TestFixture]
    public class NumberTests
    {
        [Test]
        public void NumberEvaluatesToSelf()
        {
            var sut = new Number(3);
            var result = sut.Evaluate(null);

            Assert.That(result, Is.SameAs(sut));
        }
    }
}

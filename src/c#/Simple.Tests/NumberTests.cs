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
            var sut = new Number(0);
            var result = sut.Evaluate(null);

            Assert.That(result, Is.SameAs(sut));
        }

        [Test]
        public void NumberValueIsTheOnePassedInConstructor()
        {
            var value = 7;
            var sut = new Number(value);

            Assert.That(sut.Value, Is.EqualTo(value));
        }
    }
}

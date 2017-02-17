using NUnit.Framework;
using StringCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStringCalulator
{
    [TestFixture]
    public class TestCalculator
    {
        Calculator calc;

        [SetUp]
        public void SetUp()
        {
            calc = new Calculator();
        }

        [Test]
        public void TestZero()
        {
            var result = calc.Resolve(string.Empty);
            Assert.AreEqual(result, 0);
        }

        [TestCase("1",1)]
        [TestCase("2",2)]
        [TestCase("3",3)]
        [TestCase("4",4)]
        public void TestNumber(string testNumber,int expected)
        {
            var result = calc.Resolve(testNumber);
            Assert.AreEqual(result, expected);
        }

         [Test]
         public void TestMultipleNumber()
         {
             var result = calc.Resolve("2,2,3");
             Assert.AreEqual(result, 7);
         }
    }
}

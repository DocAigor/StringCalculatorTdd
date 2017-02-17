using Moq;
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

         [TestCase("2,2,3", 7)]
         [TestCase("1,2,5", 8)]
         [TestCase("-2,1,0", -1)]
         [TestCase("0,0", 0)]
         [TestCase("-1,-2,-3,0", -6)]
         public void TestMultipleNumber(string testString,int expected)
         {
             var result = calc.Resolve(testString);
             Assert.AreEqual(result, expected);
         }

        [Test]
         public void TestMixedString()
         {
             var result = calc.Resolve("1,2,a,b,0");
             Assert.AreEqual(result, 3);
         }

        [Test]
        public void TestISaveHistory()
        {
            Mock<IHistoryCalculator> moccking = new Mock<IHistoryCalculator>();
            var calc = new Calculator(moccking.Object);
            var result = calc.Resolve("1");
            moccking.Verify(mock => mock.Save(result), Times.Once);
        }

        [TestCase("2,2,3")]
        [TestCase("1,2,5")]
        [TestCase("-2,1,0")]
        [TestCase("0,0")]
        [TestCase("-1,-2,-3,0")]
        public void TestISaveHistoryMultiple(string testString)
        {
            Mock<IHistoryCalculator> moccking = new Mock<IHistoryCalculator>();
            var calc = new Calculator(moccking.Object);
            var result = calc.Resolve(testString);
            moccking.Verify(mock => mock.Save(result), Times.Once);
        }
    }
}

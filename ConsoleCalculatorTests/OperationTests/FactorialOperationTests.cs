using System;
using ConsoleCalculator.Operands;
using ConsoleCalculator.Operations;
using NUnit.Framework;

namespace ConsoleCalculator.OperationTests.Tests
{
    [TestFixture]
    public class FactorialOperationTests
    {
        private readonly RawOperand _rawNegativeOne = new RawOperand(-1);
        private readonly RawOperand _rawZero = new RawOperand(0);
        private readonly RawOperand _rawOne = new RawOperand(1);
        private readonly RawOperand _rawTwo = new RawOperand(2);
        private readonly RawOperand _rawFour = new RawOperand(4);
        
        [Test]
        public void TestFactorialNegative()
        {
            FactorialOperation factorialOperation = new FactorialOperation(_rawNegativeOne);

            Assert.Throws(
                Is.TypeOf<ArgumentException>().
                And.Message.EqualTo("Factorial input cannot be negative") ,
                () => { factorialOperation.GetValue(); }
                );
        }

        [Test]
        public void TestFactorialZero()
        {
            FactorialOperation factorialOperation = new FactorialOperation(_rawZero);

            double result = factorialOperation.GetValue();
            Assert.AreEqual(result, 1);
        }
        
        [Test]
        public void TestFactorialOne()
        {
            FactorialOperation factorialOperation = new FactorialOperation(_rawOne);

            double result = factorialOperation.GetValue();
            Assert.AreEqual(result, 1);
        }
        
        [Test]
        public void TestFactorialTwo()
        {
            FactorialOperation factorialOperation = new FactorialOperation(_rawTwo);

            double result = factorialOperation.GetValue();
            Assert.AreEqual(result, 2);
        }
        
        [Test]
        public void TestFactorialGreaterThanTwo()
        {
            FactorialOperation factorialOperation = new FactorialOperation(_rawFour);

            double result = factorialOperation.GetValue();
            Assert.AreEqual(result, 24);
        }
    }
}
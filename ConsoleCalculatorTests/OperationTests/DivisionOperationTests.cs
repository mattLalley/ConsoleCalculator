using System;
using ConsoleCalculator.Operands;
using ConsoleCalculator.Operations;
using NUnit.Framework;

namespace ConsoleCalculator.OperationTests.Tests
{
    [TestFixture]
    public class DivisionOperationTests
    {
        private readonly RawOperand _rawZero = new RawOperand(0);
        private readonly RawOperand _rawTwo = new RawOperand(2);
        private readonly RawOperand _rawFour = new RawOperand(4);
        
        [Test]
        public void TestDivision()
        {
            DivisionOperation divisionOperation = new DivisionOperation(_rawFour, _rawTwo);

            double result = divisionOperation.GetValue();
            Assert.AreEqual(result, 2);
        }

        [Test]
        public void TestDivideByZero()
        {
            DivisionOperation divisionOperation = new DivisionOperation(_rawTwo, _rawZero);

            double result = divisionOperation.GetValue();
            Assert.IsTrue(Double.IsInfinity(result));
        }

        [Test]
        public void TestDivideZero()
        {
            DivisionOperation divisionOperation = new DivisionOperation(_rawZero, _rawTwo);
            
            double result = divisionOperation.GetValue();
            Assert.AreEqual(result, 0);
        }
    }
}
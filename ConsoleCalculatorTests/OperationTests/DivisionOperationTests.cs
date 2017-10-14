using System;
using NUnit.Framework;

namespace ConsoleCalculator.OperationTests.Tests
{
    [TestFixture]
    public class DivisionOperationTests
    {
        [Test]
        public void TestDivision()
        {
            DivisionCommand divisionCommand = new DivisionCommand
            {
                Value1 = 4,
                Value2 = 2
            };

            double result = divisionCommand.Execute();
            Assert.AreEqual(result, 2);
        }

        [Test]
        public void TestDivideByZero()
        {
            DivisionCommand divisionCommand = new DivisionCommand
            {
                Value1 = 2,
                Value2 = 0 
            };

            double result = divisionCommand.Execute();
            Assert.IsTrue(Double.IsInfinity(result));
        }

        [Test]
        public void TestDivideZero()
        {
            DivisionCommand divisionCommand = new DivisionCommand
            {
                Value1 = 0,
                Value2 = 2
            };
            double result = divisionCommand.Execute();
            Assert.AreEqual(result, 0);
        }
    }
}
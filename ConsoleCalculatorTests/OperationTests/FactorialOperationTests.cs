using System;
using NUnit.Framework;

namespace ConsoleCalculator.OperationTests.Tests
{
    [TestFixture]
    public class FactorialOperationTests
    {
        [Test]
        public void TestFactorialNegative()
        {
            FactorialCommand factorialCommand = new FactorialCommand
            {
                Value1 = -1
            };

            Assert.Throws(
                Is.TypeOf<ArgumentException>().
                And.Message.EqualTo("Factorial input cannot be negative") ,
                () => { factorialCommand.Execute(); }
                );
        }

        [Test]
        public void TestFactorialZero()
        {
            FactorialCommand factorialCommand = new FactorialCommand
            {
                Value1 = 0 
            };

            double result = factorialCommand.Execute();
            Assert.AreEqual(result, 1);
        }
        
        [Test]
        public void TestFactorialOne()
        {
            FactorialCommand factorialCommand = new FactorialCommand
            {
                Value1 = 1 
            };

            double result = factorialCommand.Execute();
            Assert.AreEqual(result, 1);
        }
        
        [Test]
        public void TestFactorialTwo()
        {
            FactorialCommand factorialCommand = new FactorialCommand
            {
                Value1 = 2 
            };

            double result = factorialCommand.Execute();
            Assert.AreEqual(result, 2);
        }
        
        [Test]
        public void TestFactorialGreaterThanTwo()
        {
            FactorialCommand factorialCommand = new FactorialCommand
            {
                Value1 = 4
            };

            double result = factorialCommand.Execute();
            Assert.AreEqual(result, 24);
        }
    }
}
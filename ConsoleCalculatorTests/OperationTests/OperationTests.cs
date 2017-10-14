using ConsoleCalculator.Operations;
using NUnit.Framework;

namespace ConsoleCalculator.OperationTests.Tests
{
    [TestFixture]
    public class OperationTests
    {
        [Test]
        public void TestAddtion()
        {
            AdditionCommand additionCommand = new AdditionCommand(2, 3);

            double result = additionCommand.Execute();
            Assert.AreEqual(result, 5);
        }

        [Test]
        public void TestSubtraction()
        {
            SubtractionCommand subtractionCommand = new SubtractionCommand(3, 2);

            double result = subtractionCommand.Execute();
            Assert.AreEqual(result, 1);
        }
        
        [Test]
        public void TestMultiplication()
        {
            MultiplicationCommand multiplicationCommand = new MultiplicationCommand(3, 2);

            double result = multiplicationCommand.Execute();
            Assert.AreEqual(result, 6);
        }
        
        [Test]
        public void TestReciprocal()
        {
            ReciprocalCommand reciprocalCommand = new ReciprocalCommand(4);

            double result = reciprocalCommand.Execute();
            Assert.AreEqual(result, .25);
        }
        
        [Test]
        public void TestFactorial()
        {
            FactorialCommand factorialCommand = new FactorialCommand(4);

            double result = factorialCommand.Execute();
            Assert.AreEqual(result, 24);
        }
    }
}
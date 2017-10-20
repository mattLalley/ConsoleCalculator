using ConsoleCalculator.Operands;
using ConsoleCalculator.Operations;
using NUnit.Framework;

namespace ConsoleCalculator.OperationTests.Tests
{
    [TestFixture]
    public class OperationTests
    {
        private readonly RawOperand _rawTwo = new RawOperand(2);
        private readonly RawOperand _rawThree = new RawOperand(3);
        private readonly RawOperand _rawFour = new RawOperand(4);
        
        [Test]
        public void TestAddtion()
        {
            AdditionOperation additionOperation = new AdditionOperation(_rawTwo, _rawThree);

            double result = additionOperation.GetValue();
            Assert.AreEqual(result, 5);
        }

        [Test]
        public void TestSubtraction()
        {
            SubtractionOperation subtractionOperation = new SubtractionOperation(_rawThree, _rawTwo);

            double result = subtractionOperation.GetValue();
            Assert.AreEqual(result, 1);
        }
        
        [Test]
        public void TestMultiplication()
        {
            MultiplicationOperation multiplicationOperation = new MultiplicationOperation(_rawThree, _rawTwo);

            double result = multiplicationOperation.GetValue();
            Assert.AreEqual(result, 6);
        }
        
        [Test]
        public void TestReciprocal()
        {
            ReciprocalOperation reciprocalOperation = new ReciprocalOperation(_rawFour);

            double result = reciprocalOperation.GetValue();
            Assert.AreEqual(result, .25);
        }
        
        [Test]
        public void TestFactorial()
        {
            FactorialOperation factorialOperation = new FactorialOperation(_rawFour);

            double result = factorialOperation.GetValue();
            Assert.AreEqual(result, 24);
        }
    }
}
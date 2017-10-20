using ConsoleCalculator.Operands;
using NUnit.Framework;

namespace ConsoleCalculator.OperandTests.Tests
{
    [TestFixture]
    public class RawOperandTests
    {
        [Test]
        public void TestRawOperand()
        {
            RawOperand rawOperand = new RawOperand(5);
            
            Assert.AreEqual(rawOperand.GetValue(), 5);
        }

        [Test]
        public void TestRawOperandEquals()
        {
            RawOperand rawOperand1 = new RawOperand(5);
            RawOperand rawOperand2 = new RawOperand(5);
            
            Assert.IsTrue(rawOperand1.Equals(rawOperand2));
        }

        [Test]
        public void TestRawOperandIsEmpty()
        {
            RawOperand rawOperand1 = new RawOperand();

            Assert.IsTrue(rawOperand1.IsEmpty());
        }

        [Test]
        public void TestRawOperandIsNotEmpty()
        {
            RawOperand rawOperand1 = new RawOperand(2);

            Assert.IsFalse(rawOperand1.IsEmpty());
        }
    }
}
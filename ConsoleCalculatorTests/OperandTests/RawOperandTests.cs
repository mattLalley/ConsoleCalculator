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
    }
}
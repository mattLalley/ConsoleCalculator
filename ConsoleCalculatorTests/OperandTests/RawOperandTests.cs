using NUnit.Framework;

namespace ConsoleCalculator.OperandTests.Tests
{
    [TestFixture]
    public class RawOperandTests
    {
        [Test]
        public void TestRawOperand()
        {
            RawOperand rawOperand = new RawOperand();
            rawOperand.SetValue(5);
            
            Assert.AreEqual(rawOperand.GetValue(), 5);
        }
    }
}
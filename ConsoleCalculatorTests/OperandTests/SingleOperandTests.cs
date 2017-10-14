using ConsoleCalculator.Operands;
using ConsoleCalculator.Operations;
using NUnit.Framework;

namespace ConsoleCalculator.OperandTests.Tests
{
    [TestFixture]
    public class SingleOperandTests
    {
        [Test]
        public void TestSingleOperand()
        {
            FactorialCommand command = new FactorialCommand(10);
            SingleOperand operand = new SingleOperand(command);

            double result = operand.GetValue();
            Assert.AreEqual(result, 3628800);
        }
    }
}
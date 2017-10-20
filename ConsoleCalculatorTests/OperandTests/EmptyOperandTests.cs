using System;
using ConsoleCalculator.Operands;
using ConsoleCalculator.Operations;
using NUnit.Framework;

namespace ConsoleCalculator.OperandTests.Tests
{
    [TestFixture]
    public class EmptyOperandtests
    {
        [Test]
        public void TestEmptyOperandGetValue()
        {
            EmptyOperand emptyOperand = new EmptyOperand();
            
            Assert.AreEqual(emptyOperand.GetValue(), 0);
        }

        [Test]
        public void TestEmptyOperandEquals()
        {
            EmptyOperand emptyOperand1 = new EmptyOperand();
            EmptyOperand emptyOperand2 = new EmptyOperand();
            
            Assert.IsTrue(emptyOperand1.Equals(emptyOperand2));
        }
        
        [Test]
        public void TestEmptyOperandNotEqual()
        {
            EmptyOperand emptyOperand1 = new EmptyOperand();
            IOperand rawOperand = new RawOperand();
            
            Assert.IsFalse(emptyOperand1.Equals(rawOperand));
        }

        [Test]
        public void TestEmptyOperandIsEmpty()
        {
            EmptyOperand emptyOperand1 = new EmptyOperand();
            
            Assert.IsTrue(emptyOperand1.IsEmpty());
        }
    }
}
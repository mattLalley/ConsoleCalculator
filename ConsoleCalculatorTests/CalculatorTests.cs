using System;
using System.Runtime;
using System.Runtime.InteropServices;
using ConsoleCalculator.Operands;
using ConsoleCalculator.Operations;
using NUnit.Framework;

namespace ConsoleCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void PushOperandTest()
        {
            Calculator calculator = new Calculator();
            calculator.PushOperand(2);

            IOperand calculatorOperand = calculator.RootOperand;
            IOperand expectedOperand = new RawOperand(2);
            Assert.IsTrue(calculatorOperand.Equals(expectedOperand));
        }

        [Test]
        public void PushOperatorTest()
        {
            Calculator calculator = new Calculator();
            calculator.PushOperation(Calculator.OperationType.Addition);

            IOperand additionOperand = new AdditionOperation();

            IOperand calculatorOperand = calculator.RootOperand;
            Assert.IsTrue(calculatorOperand.Equals(additionOperand));
        }

        [Test]
        public void PushSimpleOperation()
        {
            Calculator calculator = new Calculator();
            calculator.PushOperand(2);
            calculator.PushOperation(Calculator.OperationType.Addition);
            calculator.PushOperand(5);

            IOperand calculatorOperand = calculator.RootOperand;
            IOperation expectedOperands = new AdditionOperation();
            expectedOperands.LeftOperand = new RawOperand(2);
            expectedOperands.RightOperand = new RawOperand(5);

            Assert.IsTrue(calculatorOperand.Equals(expectedOperands));
        }

        [Test]
        public void pushComplexOperationTest()
        {
            // Push the operation 2 + 5 x 3! / 2
            Calculator calculator = new Calculator();
            calculator.PushOperand(2);
            calculator.PushOperation(Calculator.OperationType.Addition);
            calculator.PushOperand(5);
            calculator.PushOperation(Calculator.OperationType.Multiplication);
            calculator.PushOperand(3);
            calculator.PushOperation(Calculator.OperationType.Factorial);
            calculator.PushOperation(Calculator.OperationType.Division);
            calculator.PushOperand(2);

            IOperand calculatorOperand = calculator.RootOperand;

            IOperation expectedOperands =
                new AdditionOperation(
                    new RawOperand(2),
                    new DivisionOperation(
                        new MultiplicationOperation(
                            new RawOperand(5),
                            new FactorialOperation(
                                new RawOperand(3)
                            )
                        ),
                        new RawOperand(2)
                    )
                );

            Assert.IsTrue(calculatorOperand.Equals(expectedOperands));
        }

        [Test]
        public void PushConsecutiveNubmersTest()
        {
            Calculator calculator = new Calculator();
            calculator.PushOperand(2);
            calculator.PushOperand(10);
            
            IOperand calculatorOperand = calculator.RootOperand;
            IOperand expectedOperand = new RawOperand(10);
            
            Assert.IsTrue(calculatorOperand.Equals(expectedOperand));
        }

        [Test]
        public void PushNumberAfterFactorialTest()
        {
            Calculator calculator = new Calculator();
            calculator.PushOperand(5);
            calculator.PushOperation(Calculator.OperationType.Factorial);

            Assert.Throws(
                Is.TypeOf<ArgumentException>().And.Message
                    .EqualTo("Cannot push a number directly after a reciprocal or factorial operaiton"),
                () => { calculator.PushOperand(2); }
            );
        }

        [Test]
        public void CalculateSimpleCalculationResult()
        {
            Calculator calculator = new Calculator();
            calculator.PushOperand(2);
            calculator.PushOperation(Calculator.OperationType.Addition);
            calculator.PushOperand(5);
            
            calculator.CalculateResult();
            Assert.AreEqual(7, calculator.Result);
        }
        
        [Test]
        public void CalculateComplexCalculationResult()
        {
            // 2 + 5 * 3! / 2
            Calculator calculator = new Calculator();
            calculator.PushOperand(2);
            calculator.PushOperation(Calculator.OperationType.Addition);
            calculator.PushOperand(5);
            calculator.PushOperation(Calculator.OperationType.Multiplication);
            calculator.PushOperand(3);
            calculator.PushOperation(Calculator.OperationType.Factorial);
            calculator.PushOperation(Calculator.OperationType.Division);
            calculator.PushOperand(2);
            
            calculator.CalculateResult();
            Assert.AreEqual(17, calculator.Result);
        }

        [Test]
        public void LeadingNegativeSignTest()
        {
            // Perform calculation -2 + 5
            Calculator calculator = new Calculator();
            calculator.PushOperation(Calculator.OperationType.Subtraction);
            calculator.PushOperand(2);
            calculator.PushOperation(Calculator.OperationType.Addition);
            calculator.PushOperand(5);
            
            calculator.CalculateResult();
            Assert.AreEqual(3, calculator.Result);
        }

        [Test]
        public void ClearPreviousNumberTest()
        {
            Calculator calculator = new Calculator();
            calculator.PushOperand(2);
            calculator.PushOperation(Calculator.OperationType.Addition);
            calculator.PushOperand(5);
            calculator.ClearPreviousNumber();
            calculator.PushOperand(2);
            
            calculator.CalculateResult();
            Assert.AreEqual(4, calculator.Result);
        }

        [Test]
        public void ClearAllTest()
        {
            Calculator calculator = new Calculator();
            calculator.ClearAll();

            Assert.AreEqual(0, calculator.Result);
            Assert.AreEqual("", calculator.ResultText);
            Assert.IsTrue(new EmptyOperand().Equals(calculator.RootOperand));
        }

        [Test]
        public void ResultTextTest()
        {
            Calculator calculator = new Calculator();
            calculator.PushOperand(4);
            calculator.PushOperation(Calculator.OperationType.Addition);
            calculator.PushOperand(4);
            calculator.CalculateResult();
            
            Assert.AreEqual("8", calculator.ResultText);
        }

        [Test]
        public void ClearResultTextTest()
        {
            Calculator calculator = new Calculator();
            calculator.PushOperand(4);
            calculator.PushOperation(Calculator.OperationType.Addition);
            calculator.PushOperand(4);
            calculator.CalculateResult();
            calculator.PushOperand(5);
            
            Assert.AreEqual("", calculator.ResultText);
        }
    }
}
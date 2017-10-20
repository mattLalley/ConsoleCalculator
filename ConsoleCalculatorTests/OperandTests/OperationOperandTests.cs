using ConsoleCalculator.Operands;
using ConsoleCalculator.Operations;
using NUnit.Framework;

namespace ConsoleCalculator.OperandTests.Tests
{
    [TestFixture]
    public class OperationTests
    {
        private readonly RawOperand _rawTwo = new RawOperand(2);
        private readonly RawOperand _rawThree = new RawOperand(3);
        private readonly RawOperand _rawFour = new RawOperand(4);
        private readonly RawOperand _rawTen = new RawOperand(10);
        
        [Test]
        public void TestAddition()
        {
            IOperation operationOperand = new AdditionOperation(); 
            operationOperand.LeftOperand = _rawTwo;
            operationOperand.RightOperand = _rawFour;

            double result = operationOperand.GetValue();
            Assert.AreEqual(result, 6);
        }

        [Test]
        public void TestSubtraction()
        {
            IOperation operationOperand = new SubtractionOperation(); 
            operationOperand.LeftOperand = _rawTwo;
            operationOperand.RightOperand = _rawFour;

            double result = operationOperand.GetValue();
            Assert.AreEqual(result, -2);
        }

        [Test]
        public void TestMultiplication()
        {
            IOperation operationOperand = new MultiplicationOperation();
            operationOperand.LeftOperand = _rawTwo;
            operationOperand.RightOperand = _rawFour;

            double result = operationOperand.GetValue();
            Assert.AreEqual(result, 8);
        }

        [Test]
        public void TestDivision()
        {
            IOperation operationOperand = new DivisionOperation();
            operationOperand.LeftOperand = _rawTwo;
            operationOperand.RightOperand = _rawFour;

            double result = operationOperand.GetValue();
            Assert.AreEqual(result, .5);
        }
        
        [Test]
        public void TestFactorial()
        {
            IOperation operation = new FactorialOperation();;
            operation.LeftOperand = _rawTen;

            double result = operation.GetValue();
            Assert.AreEqual(result, 3628800);
        }
        
        [Test]
        public void TestReciprocal()
        {
            IOperation operation = new ReciprocalOperation();;
            operation.LeftOperand = _rawTen;

            double result = operation.GetValue();
            Assert.AreEqual(result, .1);
        }

        [Test]
        public void TestOperandTree()
        {
            IOperation leftOperationOperand = new AdditionOperation();
            leftOperationOperand.LeftOperand = _rawTen;
            leftOperationOperand.RightOperand = _rawFour;
            
            IOperation rightOperationOperand = new MultiplicationOperation();
            rightOperationOperand.LeftOperand = _rawThree;
            rightOperationOperand.RightOperand = _rawFour;
            
            IOperation rootOperationOperand = new SubtractionOperation();
            rootOperationOperand.LeftOperand = leftOperationOperand;
            rootOperationOperand.RightOperand = rightOperationOperand;

            double result = rootOperationOperand.GetValue();
            Assert.AreEqual(result, 2);
        }

        [Test]
        public void TestOperationOperandEquality()
        {
            IOperation operand1 = new AdditionOperation();
            operand1.LeftOperand = _rawThree;
            operand1.RightOperand = _rawFour;
            
            IOperation operand2 = new AdditionOperation();
            operand2.LeftOperand = _rawThree;
            operand2.RightOperand = _rawFour;
            
            Assert.IsTrue(operand1.Equals(operand2));
        }
        
        [Test]
        public void TestOperationOperandInEqualityType()
        {
            IOperation operand1 = new MultiplicationOperation();
            operand1.LeftOperand = _rawThree;
            operand1.RightOperand = _rawFour;
            
            IOperation operand2 = new AdditionOperation();
            operand2.LeftOperand = _rawThree;
            operand2.RightOperand = _rawFour;
            
            Assert.IsFalse(operand1.Equals(operand2));
        }
        
        [Test]
        public void TestOperationOperandInEqualityContents()
        {
            IOperation operand1 = new AdditionOperation();
            operand1.LeftOperand = _rawTen;
            operand1.RightOperand = _rawFour;
            
            IOperation operand2 = new AdditionOperation();
            operand2.LeftOperand = _rawThree;
            operand2.RightOperand = _rawFour;
            
            Assert.IsFalse(operand1.Equals(operand2));
        }

        [Test]
        public void TestEmptyOperationEquality()
        {
            IOperation operand1 = new AdditionOperation();
            IOperation operand2 = new AdditionOperation();
            
            Assert.IsTrue(operand1.Equals(operand2));
        }
        
        [Test]
        public void TestOperationIsEmpty()
        {
            IOperand operand = new AdditionOperation();
            Assert.IsTrue(operand.IsEmpty());
        }

        [Test]
        public void TestOperationIsNotEmpty()
        {
            IOperation operand = new AdditionOperation();
            operand.LeftOperand = new RawOperand();
            
            Assert.IsFalse(operand.IsEmpty());
        }

        [Test]
        public void TestOperationLessThanPrecedence()
        {
            IOperation addOperation = new AdditionOperation();
            IOperation multiplyOperation = new MultiplicationOperation();
            
            Assert.Less(addOperation.PrecedenceLevel, multiplyOperation.PrecedenceLevel);
        }
        
        [Test]
        public void TestOperationEqualPrecedence()
        {
            IOperation addOperation = new AdditionOperation();
            IOperation subtractionOperation = new SubtractionOperation();
            
            Assert.AreEqual(addOperation.PrecedenceLevel, subtractionOperation.PrecedenceLevel);
        }
        
        [Test]
        public void TestOperand()
        {
            // Simulate operation 2 + 3 * 4
            
            // Allocate the root node
            IOperand rootOperand;
            
            // Create the raw operand for the number 2
            IOperand rawOperandTwo = new RawOperand(2);
            
            // Set the root node as the first rawoperand
            rootOperand = rawOperandTwo;
            
            Assert.AreEqual(2, rootOperand.GetValue());
            
            // Create the operation for + and store it in an operand     
            IOperation addOperation = new AdditionOperation();
            
            // Set the left operand of the add operations operand to the rawOperand
            addOperation.LeftOperand = rootOperand;
            
            // Set the root operand to the new addOperand
            rootOperand = addOperation;
            
            // Create the raw operand for the number 3 and set it as the right operand of the add operation
            IOperand rawOperandThree = new RawOperand(3);
            addOperation.RightOperand = rawOperandThree;
            
            Assert.AreEqual(5, rootOperand.GetValue());
            
            // Create the operation for * and store it in an operand
            IOperation multiplyOperation = new MultiplicationOperation();

            // Move the addOperand's right operand to the multiplyOperand left's operand
            multiplyOperation.LeftOperand = addOperation.RightOperand;
            
            // Set the multiply operand and the addOperand's Right operand
            addOperation.RightOperand = multiplyOperation;
            
            // Create and set the right side of the mutliply operand
            IOperand rawOperandFour = new RawOperand(4);
            multiplyOperation.RightOperand = rawOperandFour;
            
            Assert.AreEqual(14, rootOperand.GetValue());
        }
    }
}
using System;
using ConsoleCalculator.Operands;
using ConsoleCalculator.Operations;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public enum OperationType
        {
            Addition,
            Subtraction,
            Multiplication,
            Division,
            Factorial,
            Reciprocal,
            Empty
        }

        private IOperand _rootOperand = new EmptyOperand();
        public IOperand RootOperand => _rootOperand;

        private double _result;
        public double Result => _result;
        public String ResultText;

        public void PushOperand(double operand)
        {
            ResultText = "";
            _rootOperand = pushOperand(new RawOperand(operand), _rootOperand);
        }

        public void PushOperation(OperationType operationType)
        {
            ResultText = "";
            IOperand operation = null;
            switch (operationType)
            {
                case OperationType.Addition:
                    operation = new AdditionOperation();
                    break;
                case OperationType.Subtraction:
                    operation = new SubtractionOperation();
                    break;
                case OperationType.Multiplication:
                    operation = new MultiplicationOperation();
                    break;
                case OperationType.Division:
                    operation = new DivisionOperation();
                    break;
                case OperationType.Factorial:
                    operation = new FactorialOperation();
                    break;
                case OperationType.Reciprocal:
                    operation = new ReciprocalOperation();
                    break;
                case OperationType.Empty:
                    operation = new EmptyOperand();
                    break;
            }
            _rootOperand = pushOperand(operation, _rootOperand);
        }

        private IOperand pushOperand(IOperand newOperand, IOperand existingOperand)
        {
            if (existingOperand is EmptyOperand)
            {
                return newOperand;
            }

            if (newOperand.PrecedenceLevel <= existingOperand.PrecedenceLevel)
            {
                if (newOperand is RawOperand)
                {
                    return newOperand;
                }

                IOperation newOperation = (IOperation) newOperand;
                newOperation.LeftOperand = existingOperand;
                return newOperation;
            }

            if ((existingOperand is ReciprocalOperation || existingOperand is FactorialOperation) &&
                newOperand is RawOperand)
            {
                throw new ArgumentException("Cannot push a number directly after a reciprocal or factorial operaiton");
            }

            IOperation existingOperation = (IOperation) existingOperand;
            existingOperation.RightOperand = pushOperand(newOperand, existingOperation.RightOperand);
            return existingOperation;
        }

        public void CalculateResult()
        {
            _result = _rootOperand.GetValue();
            _rootOperand = new RawOperand(_result);
            ResultText = _result + "";
        }

        public void ClearPreviousNumber()
        {
            ResultText = "";
            _rootOperand = pushOperand(new RawOperand(0), _rootOperand);
        }

        public void ClearAll()
        {
            _rootOperand = new EmptyOperand();
            _result = 0;
            ResultText = "";
        }
    }
}
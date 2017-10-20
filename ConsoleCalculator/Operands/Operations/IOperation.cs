using System;
using ConsoleCalculator.Operands;
using ConsoleCalculator.Operations;

namespace ConsoleCalculator
{
    public abstract class IOperation : IOperand
    {
        public IOperation()
        {
            _leftOperand = new EmptyOperand();
            _rightOperand = new EmptyOperand();
        }
        
        public IOperation(IOperand leftOperand, IOperand rightOperand)
        {
            _leftOperand = leftOperand;
            _rightOperand = rightOperand;
        }

        private IOperand _leftOperand;
        public IOperand LeftOperand
        {
            get { return _leftOperand; }
            set { _leftOperand = value; }
        }

        private IOperand _rightOperand;
        public IOperand RightOperand
        {
            get { return _rightOperand; }
            set { _rightOperand = value; }
        }

        protected int _precedenceLevel;
        public int PrecedenceLevel => _precedenceLevel;

        public abstract double GetValue();

        public bool Equals(IOperand operand)
        {
            if (ReferenceEquals(this, operand)) return true;
            if (ReferenceEquals(operand, null)) return false;
            if (GetType() != operand.GetType()) return false;
            IOperation operation = (IOperation) operand;
            bool lhs = _leftOperand.Equals(operation.LeftOperand);
            bool rhs = _rightOperand.Equals(operation.RightOperand);
            return _leftOperand.Equals(operation.LeftOperand) && _rightOperand.Equals(operation.RightOperand);
        }

        public bool IsEmpty()
        {
            return _leftOperand is EmptyOperand && _rightOperand is EmptyOperand;
        }
    }
}
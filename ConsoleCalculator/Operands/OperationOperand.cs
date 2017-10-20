using System.Collections.Generic;

namespace ConsoleCalculator.Operands
{
    public class OperationOperand : IOperand
    {
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

        private IOperation _operation;

        public IOperation Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        public double GetValue()
        {
            _operation.LeftOperand = _leftOperand;
            _operation.RightOperand = _rightOperand;
            return _operation.GetValue();
        }

        public bool Equals(IOperand operand)
        {
            if (ReferenceEquals(this, operand)) return true;
            if (ReferenceEquals(operand, null)) return false;
            if (GetType() != operand.GetType()) return false;
            OperationOperand operationOperand = (OperationOperand) operand;
            return _leftOperand.Equals(operationOperand.LeftOperand) && _rightOperand.Equals(operationOperand.RightOperand) && _operation.Equals(operationOperand.Operation);
        }

        public bool IsEmpty()
        {
            throw new System.NotImplementedException();
        }

        public int PrecedenceLevel { get; }

        private sealed class OperationOperandEqualityComparer : IEqualityComparer<OperationOperand>
        {
            public bool Equals(OperationOperand x, OperationOperand y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return Equals(x._leftOperand, y._leftOperand) && Equals(x._rightOperand, y._rightOperand) &&
                       Equals(x._operation, y._operation);
            }

            public int GetHashCode(OperationOperand obj)
            {
                unchecked
                {
                    var hashCode = (obj._leftOperand != null ? obj._leftOperand.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj._rightOperand != null ? obj._rightOperand.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj._operation != null ? obj._operation.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<OperationOperand> OperationOperandComparer { get; } =
            new OperationOperandEqualityComparer();
    }
}
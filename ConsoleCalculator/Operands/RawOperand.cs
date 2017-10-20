using System;

namespace ConsoleCalculator.Operands
{
    public class RawOperand : IOperand
    {
        public RawOperand()
        {
            _value = Double.NaN;
            _precedenceLevel = 3;
        }
        
        public RawOperand(double value)
        {
            _value = value;
            _precedenceLevel = 3;
        }

        private double _value;

        public double GetValue()
        {
            return _value;
        }

        public bool Equals(IOperand operand)
        {
            if (ReferenceEquals(this, operand)) return true;
            if (ReferenceEquals(operand, null)) return false;
            if (GetType() != operand.GetType()) return false;
            return _value.Equals(operand.GetValue());
        }

        public bool IsEmpty()
        {
            return Double.IsNaN(_value);
        }

        private readonly int _precedenceLevel = 3;
        public int PrecedenceLevel => _precedenceLevel;
    }
}
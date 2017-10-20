using System;
using ConsoleCalculator.Operands;

namespace ConsoleCalculator.Operations
{
    public class EmptyOperand : IOperand
    {
        public double GetValue()
        {
            return 0;
        }

        private readonly int _precedenceLevel = -1;
        public int PrecedenceLevel { get; }

        public bool Equals(IOperand operand)
        {
            if (ReferenceEquals(this, operand)) return true;
            if (ReferenceEquals(operand, null)) return false;
            if (GetType() != operand.GetType()) return false;
            return true;
        }

        public bool IsEmpty()
        {
            return true;
        }
    }
}
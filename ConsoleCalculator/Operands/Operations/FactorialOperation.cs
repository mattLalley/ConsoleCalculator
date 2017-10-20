using System;
using ConsoleCalculator.Operands;

namespace ConsoleCalculator.Operations
{
    public class FactorialOperation : IOperation
    {
        public FactorialOperation()
        {
            _precedenceLevel = 2;
        }

        public FactorialOperation(IOperand leftOperand) : base(leftOperand, new EmptyOperand())
        {
            
            _precedenceLevel = 2;
        }
        
        public override double GetValue()
        {
            return CalculateFactorial(LeftOperand.GetValue());
        }

        private double CalculateFactorial(double value)
        {
            int integerValue = (int) value;
            if (integerValue < 0)
            {
                throw new ArgumentException("Factorial input cannot be negative");
            }
            if (integerValue == 0)
            {
                return 1;
            }
            
            if (integerValue == 1 || integerValue == 2)
            {
                return integerValue;
            }

            int result = 2;
            for (int i = 3; i <= integerValue; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
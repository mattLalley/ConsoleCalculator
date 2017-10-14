using System;

namespace ConsoleCalculator.Operations
{
    public class FactorialCommand : IOperationCommand
    {
        public FactorialCommand(double leftOperand) : base(leftOperand, Double.NaN) {}
        
        public override double Execute()
        {
            return CalculateFactorial(_leftOperand);
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
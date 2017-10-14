using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ConsoleCalculator
{
    public class FactorialCommand : IOperationCommand
    {
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Execute()
        {
            return CalculateFactorial(Value1);
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
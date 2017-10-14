using System;

namespace ConsoleCalculator.Operations
{
    public class ReciprocalCommand : IOperationCommand
    {
        public ReciprocalCommand(double leftOperand) : base(leftOperand, Double.NaN) {}
        
        public override double Execute()
        {
            return 1 / _leftOperand;
        }
    }
}
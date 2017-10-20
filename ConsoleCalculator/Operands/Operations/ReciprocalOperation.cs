using System;
using ConsoleCalculator.Operands;

namespace ConsoleCalculator.Operations
{
    public class ReciprocalOperation : IOperation
    {
        public ReciprocalOperation()
        {
            _precedenceLevel = 2;
        }

        public ReciprocalOperation(IOperand leftOperand) : base(leftOperand, new EmptyOperand())
        {
            _precedenceLevel = 2;
        }
        
        public override double GetValue()
        {
            return 1 / LeftOperand.GetValue();
        }
    }
}
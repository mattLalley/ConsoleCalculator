using System;

namespace ConsoleCalculator
{
    public abstract class IOperationCommand
    {
        public IOperationCommand()
        {
            _leftOperand = Double.NaN;
            _rightOperand = Double.NaN;
        }
        
        public IOperationCommand(double leftOperand, double rightOperand)
        {
            _leftOperand = leftOperand;
            _rightOperand = rightOperand;
        }

        protected double _leftOperand;
        protected double _rightOperand;
        
        public abstract double Execute();
    }
}
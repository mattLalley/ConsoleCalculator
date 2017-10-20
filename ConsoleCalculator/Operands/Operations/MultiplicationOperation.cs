using ConsoleCalculator.Operands;

namespace ConsoleCalculator.Operations
{
    public class MultiplicationOperation : IOperation
    {
        public MultiplicationOperation()
        {
            _precedenceLevel = 1;
        }

        public MultiplicationOperation(IOperand leftOperand, IOperand rightOperand) : base(leftOperand, rightOperand)
        {
            _precedenceLevel = 1;
        }
        
        public override double GetValue()
        {
            return LeftOperand.GetValue() * RightOperand.GetValue();
        }
    }
}
using ConsoleCalculator.Operands;

namespace ConsoleCalculator.Operations
{
    public class AdditionOperation : IOperation
    {
        public AdditionOperation() : base()
        {
            _precedenceLevel = 0;
        }

        public AdditionOperation(IOperand leftOperand, IOperand rightOperand) : base(leftOperand, rightOperand)
        {
            _precedenceLevel = 0;
        }
        
        public override double GetValue()
        {
            return LeftOperand.GetValue() + RightOperand.GetValue();
        }
    }
}
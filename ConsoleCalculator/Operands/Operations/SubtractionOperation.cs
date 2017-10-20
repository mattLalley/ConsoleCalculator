using ConsoleCalculator.Operands;

namespace ConsoleCalculator.Operations
{
    public class SubtractionOperation : IOperation
    {
        public SubtractionOperation()
        {
            LeftOperand = new RawOperand(0);
            _precedenceLevel = 0;
        }

        public SubtractionOperation(IOperand leftOperand, IOperand rightOperand) : base(leftOperand, rightOperand)
        {
            _precedenceLevel = 0;
        }
        
        public override double GetValue()
        {
            return LeftOperand.GetValue() - RightOperand.GetValue();
        }
    }
}
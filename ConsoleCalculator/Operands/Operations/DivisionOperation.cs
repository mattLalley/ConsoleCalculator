using ConsoleCalculator.Operands;

namespace ConsoleCalculator.Operations
{
    public class DivisionOperation : IOperation
    {
        public DivisionOperation() : this(new EmptyOperand(), new EmptyOperand())
        {
            _precedenceLevel = 1;
        }

        public DivisionOperation(IOperand leftOperand, IOperand rightOperand) : base(leftOperand, rightOperand)
        {
            _precedenceLevel = 1;
        }

        public override double GetValue()
        {
            return LeftOperand.GetValue() / RightOperand.GetValue();
        }
    }
}
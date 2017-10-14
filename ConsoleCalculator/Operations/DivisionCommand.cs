namespace ConsoleCalculator.Operations
{
    public class DivisionCommand : IOperationCommand
    {
        public DivisionCommand(double leftOperand, double rightOperand) : base(leftOperand, rightOperand) {}

        public override double Execute()
        {
            return _leftOperand / _rightOperand;
        }
    }
}
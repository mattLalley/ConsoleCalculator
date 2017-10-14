namespace ConsoleCalculator.Operations
{
    public class AdditionCommand : IOperationCommand
    {
        public AdditionCommand(double leftOperand, double rightOperand) : base(leftOperand, rightOperand) {}
        
        public override double Execute()
        {
            return _leftOperand + _rightOperand;
        }
    }
}
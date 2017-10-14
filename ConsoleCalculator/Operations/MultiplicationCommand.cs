namespace ConsoleCalculator.Operations
{
    public class MultiplicationCommand : IOperationCommand
    {
        public MultiplicationCommand(double leftOperand, double rightOperand) : base(leftOperand, rightOperand) {}
        
        public override double Execute()
        {
            return _leftOperand * _rightOperand;
        }
    }
}
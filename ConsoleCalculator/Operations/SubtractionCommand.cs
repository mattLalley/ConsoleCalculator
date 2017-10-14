namespace ConsoleCalculator.Operations
{
    public class SubtractionCommand : IOperationCommand
    {
        public SubtractionCommand(double leftOperand, double rightOperand) : base(leftOperand, rightOperand) {}
        
        public override double Execute()
        {
            return _leftOperand - _rightOperand;
        }
    }
}
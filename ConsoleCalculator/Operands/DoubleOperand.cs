namespace ConsoleCalculator.Operands
{
    public class DoubleOperand : IOperand
    {
        public DoubleOperand(IOperationCommand leftCommand, IOperationCommand rightCommand)
        {
            IOperationCommand _leftCommand = leftCommand;
            IOperationCommand _rightCommand = rightCommand;
        }

        private IOperationCommand _leftCommand;
        private IOperationCommand _rightCommand;

        public double GetValue()
        {
            throw new System.NotImplementedException();
        }
    }
}
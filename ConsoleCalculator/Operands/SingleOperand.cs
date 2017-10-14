namespace ConsoleCalculator.Operands
{
    public class SingleOperand : IOperand
    {
        public SingleOperand(IOperationCommand command)
        {
            _command = command;
        }
        
        private IOperationCommand _command;
        private IOperand _leftOperand;
        
        public double GetValue()
        {
            return _command.Execute();
        }
    }
}
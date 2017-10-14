using System.Dynamic;

namespace ConsoleCalculator
{
    public class SingleOperand : IOperand
    {
        public SingleOperand(IOperationCommand command)
        {
            _command = command;
        }

        private IOperationCommand _command;
        
        public double GetValue()
        {
            throw new System.NotImplementedException();
        }
    }
}
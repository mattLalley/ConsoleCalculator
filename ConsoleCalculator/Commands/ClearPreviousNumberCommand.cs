namespace ConsoleCalculator.Commands
{
    public class ClearPreviousNumberCommand : ICommand
    {
        public ClearPreviousNumberCommand(Calculator calculator)
        {
            _calculator = calculator;
        }

        private Calculator _calculator;
        
        public void Execute()
        {
            _calculator.ClearPreviousNumber();
        }
    }
}
namespace ConsoleCalculator.Commands
{
    public class ClearAllCommand : ICommand
    {
        public ClearAllCommand(Calculator calculator)
        {
            _calculator = calculator;
        }

        private Calculator _calculator;
        
        public void Execute()
        {
            _calculator.ClearAll();
        }
    }
}
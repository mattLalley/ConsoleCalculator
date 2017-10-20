using System;

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

        public void Execute(Action<String> error)
        {
            try
            {
                Execute();
            }
            catch (ArgumentException argumentException)
            {
                error(argumentException.Message);
            }
        }
    }
}
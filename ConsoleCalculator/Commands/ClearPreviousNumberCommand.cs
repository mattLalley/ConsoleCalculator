using System;

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
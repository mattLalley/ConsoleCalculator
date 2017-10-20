using System;

namespace ConsoleCalculator.Commands
{
    public class CalculateCommand : ICommand
    {
        public CalculateCommand(Calculator calculator)
        {
            _calculator = calculator;
        }

        private Calculator _calculator;

        public void Execute()
        {
            _calculator.CalculateResult();
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
using System;

namespace ConsoleCalculator.Commands
{
    public class EmptyCommand : ICommand
    {
        public void Execute() {}
        public void Execute(Action<String> error)
        {
        }
    }
}
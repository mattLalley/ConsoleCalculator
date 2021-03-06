﻿using System;

namespace ConsoleCalculator.Commands
{
    public class PushOperationCommand : ICommand
    {
        public PushOperationCommand(Calculator calculator, Calculator.OperationType operationType)
        {
            _calculator = calculator;
            _operationType = operationType;
        }

        private Calculator _calculator;
        private Calculator.OperationType _operationType;

        public void Execute()
        {
            _calculator.PushOperation(_operationType);
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
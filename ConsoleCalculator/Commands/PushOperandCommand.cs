﻿namespace ConsoleCalculator.Commands
{
    public class PushOperandCommand : ICommand
    {
        public PushOperandCommand(Calculator calculator, double value)
        {
            _calculator = calculator;
            _value = value;
        }

        private Calculator _calculator;
        private double _value;
        
        public void Execute()
        {
            _calculator.PushOperand(_value);
        }
    }
}
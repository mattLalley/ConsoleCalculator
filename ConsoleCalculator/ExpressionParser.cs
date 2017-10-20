using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ConsoleCalculator.Commands;

namespace ConsoleCalculator
{
    public class ExpressionParser
    {
        public ExpressionParser(Calculator calculator)
        {
            _calculator = calculator;
        }

        private Calculator _calculator;

        private List<ICommand> _commands;

        public List<ICommand> Commands
        {
            get { return _commands; }
            set { _commands = value; }
        }

        public bool ContainsQuitCommand(String input)
        {
            return input.Contains("Q");
        }

        public bool ContainsUnsupportedCharacters(String input)
        {
            String pattern = @"[^-+*/!=AC\d\.x\s]"; // operators
            return Regex.IsMatch(input, pattern);
        }

        public List<ICommand> ParseCommands(String input)
        {
            String pattern = @"(1\/x)|" + // reciprocal
                             @"([-+*\/!=])|" + // operators
                             @"(\d+(?:\.\d+)?)(?!\/x)|" + // numbers like 2.4 or 2
                             @"(\.\d+)|" + // numbers like .2
                             @"([AC])"; // A, C or Q
            List<ICommand> commands = new List<ICommand>();
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match m in matches)
            {
                if (m.Groups[1].Value != "")
                {
                    // Matched operation 1/x
                    Calculator.OperationType type = Calculator.OperationType.Reciprocal;
                    commands.Add(new PushOperationCommand(_calculator, type));
                }
                else if (m.Groups[2].Value != "")
                {
                    // Matched operation -+*/?=
                    commands.Add(getOperation(m.Groups[2].Value));
                }
                else if (m.Groups[3].Value != "")
                {
                    // Matched value or value.value
                    double value = Double.Parse(m.Groups[3].Value);
                    commands.Add(new PushOperandCommand(_calculator, value));
                }
                else if (m.Groups[4].Value != "")
                {
                    // Matched .value
                    double value = Double.Parse(m.Groups[4].Value);
                    commands.Add(new PushOperandCommand(_calculator, value));
                }
                else if (m.Groups[5].Value != "")
                {
                    // Matched command A (clear all), C (clear previous), Q (quit)
                    commands.Add(getCommand(m.Groups[5].Value));
                }
            }
            return commands;
        }

        private ICommand getOperation(String operation)
        {
            Calculator.OperationType type;
            switch (operation)
            {
                case "-":
                    type = Calculator.OperationType.Subtraction;
                    break;
                case "+":
                    type = Calculator.OperationType.Addition;
                    break;
                case "*":
                    type = Calculator.OperationType.Multiplication;
                    break;
                case "/":
                    type = Calculator.OperationType.Division;
                    break;
                case "!":
                    type = Calculator.OperationType.Factorial;
                    break;
                case "=":
                    return new CalculateCommand(_calculator);
                default:
                    type = Calculator.OperationType.Empty;
                    break;
            }

            return new PushOperationCommand(_calculator, type);
        }

        private ICommand getCommand(String command)
        {
            ICommand returnCommand = new EmptyCommand();
            switch (command)
            {
                case "A":
                    returnCommand = new ClearAllCommand(_calculator);
                    break;
                case "C":
                    returnCommand = new ClearPreviousNumberCommand(_calculator);
                    break;
            }
            return returnCommand;
        }
    }
}
using System;
using System.Collections.Generic;
using ConsoleCalculator.Commands;

namespace ConsoleCalculator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            ExpressionParser expressionParser = new ExpressionParser(calculator);
            List<ICommand> commands = new List<ICommand>();
            Console.WriteLine("Welcome to Console Calculator! \nPlease enter a calculation:");
            while (true) 
            {
                string input = Console.ReadLine();
                if (expressionParser.ContainsQuitCommand(input))
                {
                    Console.WriteLine("Thanks for using Console Calculator! \n");
                    break;
                }

                if (expressionParser.ContainsUnsupportedCharacters(input))
                {
                    Console.WriteLine("Unsupported characters detected");
                }
                else
                {
                    commands = expressionParser.ParseCommands(input);
                    String commandError = "";
                    commands.ForEach(command =>
                    {
                        command.Execute(error =>
                        {
                            commandError = error;
                        });
                    });
                    if (commandError != "")
                    {
                        Console.WriteLine(commandError);
                    }
                    else if (calculator.ResultText != "")
                    {
                        Console.WriteLine("Result: " + calculator.Result);
                    }
                }
            }
        }
    }
}
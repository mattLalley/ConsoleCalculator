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
            Parser parser = new Parser(calculator);
            List<ICommand> commands = new List<ICommand>();
            Console.WriteLine("Welcome to Console Calculator! \nPlease enter a calculation:");
            while (true)
            {
                string input = Console.ReadLine();
                if (parser.ContainsQuitCommand(input))
                {
                    Console.WriteLine("Thanks for using Console Calculator! \n");
                    break;
                }

                if (parser.ContainsUnsupportedCharacters(input))
                {
                    Console.WriteLine("Unsupported characters detected");
                }
                else
                {
                    commands = parser.Parse(input);
                    commands.ForEach(command => command.Execute());
                    if (calculator.ResultText != "")
                    {
                        Console.WriteLine("Result: " + calculator.Result);
                    }
                }
            }
        }
    }
}
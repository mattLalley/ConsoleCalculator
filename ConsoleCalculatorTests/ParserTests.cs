using System;
using System.Collections.Generic;
using ConsoleCalculator;
using ConsoleCalculator.Commands;
using ConsoleCalculator.Operands;
using ConsoleCalculator.Operations;
using NUnit.Framework;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class ParserTests
    {
        [Test]
        public void ParseReciprocalOperator()
        {
            Calculator calculator = new Calculator();
            String input = "1/x ";
            Parser parser = new Parser(calculator);
            List<ICommand> commands = parser.Parse(input);
            commands.Add(new CalculateCommand(calculator));
            commands.ForEach(command => command.Execute());
            
            IOperand operand = new ReciprocalOperation();
            Assert.IsTrue(operand.Equals(calculator.RootOperand));
        }

        [Test]
        public void ParseReciprocalOperator2()
        {
            Calculator calculator = new Calculator();
            String input = "101/x";
            Parser parser = new Parser(calculator);
            List<ICommand> commands = parser.Parse(input);
            commands.Add(new CalculateCommand(calculator));
            commands.ForEach(command => command.Execute());
            
            Assert.AreEqual(.1, calculator.Result);
            
        }
        
        [Test]
        public void ParseOperator()
        {
            Calculator calculator = new Calculator();
            String input = "/ ";
            Parser parser = new Parser(calculator);
            List<ICommand> commands = parser.Parse(input);
            commands.Add(new CalculateCommand(calculator));
            commands.ForEach(command => command.Execute());
            
            IOperand operand = new DivisionOperation();
            Assert.IsTrue(operand.Equals(calculator.RootOperand));
        }
        
        [Test]
        public void ParseCommand()
        {
            Calculator calculator = new Calculator();
            String input = "5A ";
            Parser parser = new Parser(calculator);
            List<ICommand> commands = parser.Parse(input);
            commands.Add(new CalculateCommand(calculator));
            commands.ForEach(command => command.Execute());
            
            Assert.AreEqual(0, calculator.Result);
        }
        
        [Test]
        public void ParseNumber()
        {
            Calculator calculator = new Calculator();
            String input = "5   ";
            Parser parser = new Parser(calculator);
            List<ICommand> commands = parser.Parse(input);
            commands.Add(new CalculateCommand(calculator));
            commands.ForEach(command => command.Execute());
            
            Assert.AreEqual(5, calculator.Result);
        }
        
        [Test]
        public void ParseMultiDigitNumber()
        {
            Calculator calculator = new Calculator();
            String input = "54   ";
            Parser parser = new Parser(calculator);
            List<ICommand> commands = parser.Parse(input);
            commands.Add(new CalculateCommand(calculator));
            commands.ForEach(command => command.Execute());
            
            Assert.AreEqual(54, calculator.Result);
        }
        
        
        [Test]
        public void ParseDecimalNumber()
        {
            Calculator calculator = new Calculator();
            String input = "5.4";
            Parser parser = new Parser(calculator);
            List<ICommand> commands = parser.Parse(input);
            commands.Add(new CalculateCommand(calculator));
            commands.ForEach(command => command.Execute());
            
            Assert.AreEqual(5.4, calculator.Result);
        }

        [Test]
        public void ParseLeadingDecimalNumber()
        {
            Calculator calculator = new Calculator();
            String input = ".4";
            Parser parser = new Parser(calculator);
            List<ICommand> commands = parser.Parse(input);
            commands.Add(new CalculateCommand(calculator));
            commands.ForEach(command => command.Execute());
            
            Assert.AreEqual(0.4, calculator.Result);
        }

        [Test]
        public void ParseAndExecuteOperationTest()
        {
            Calculator calculator = new Calculator();
            String input = "5+4=";
            Parser parser = new Parser(calculator);
            List<ICommand> commands = parser.Parse(input);
            commands.ForEach(command => command.Execute());
            
            Assert.AreEqual(9, calculator.Result);
        }

        [Test]
        public void ProblemSetTest1()
        {
            // 2+2=
            // +5=
            Calculator calculator = new Calculator();
            Parser parser = new Parser(calculator);
            String input1 = "2+2=";
            List<ICommand> commands = parser.Parse(input1);
            commands.ForEach(command => command.Execute());
            Assert.AreEqual(4, calculator.Result);
            
            String input2 = "+5=";
            List<ICommand> commands2 = parser.Parse(input2);
            commands2.ForEach(command => command.Execute());
            Assert.AreEqual(9, calculator.Result);
        }

        [Test]
        public void ProblemSetTest2()
        {
            // 7 + 8 C + 7 =
            Calculator calculator = new Calculator();
            Parser parser = new Parser(calculator);
            String input1 = "7 + 8 C + 7 =";
            List<ICommand> commands = parser.Parse(input1);
            commands.ForEach(command => command.Execute());
            Assert.AreEqual(14, calculator.Result);
        }

        [Test]
        public void ProblemSetTest3()
        {
            // -5*5/3=
            Calculator calculator = new Calculator();
            Parser parser = new Parser(calculator);
            String input1 = "-5*5/3=";
            double expectedResult = -5.0 * 5.0 / 3.0;
            List<ICommand> commands = parser.Parse(input1);
            commands.ForEach(command => command.Execute());
            Assert.AreEqual(expectedResult, calculator.Result);
        }

        [Test]
        public void ProblemSetTest4()
        {
            // 7 + - 6 =
            Calculator calculator = new Calculator();
            Parser parser = new Parser(calculator);
            String input1 = "7 + - 6 =";
            List<ICommand> commands = parser.Parse(input1);
            commands.ForEach(command => command.Execute());
            Assert.AreEqual(1, calculator.Result);
        }

        [Test]
        public void ProblemSetTest5()
        {
            // -5 * 5 - 15 / 3 =
            Calculator calculator = new Calculator();
            Parser parser = new Parser(calculator);
            String input1 = "-5 * 5 - 15 / 3 =";
            List<ICommand> commands = parser.Parse(input1);
            commands.ForEach(command => command.Execute());
            Assert.AreEqual(-30, calculator.Result);
        }

        [Test]
        public void ProblemSetTest6()
        {
            // 5! / 12 A + 9 =
            Calculator calculator = new Calculator();
            Parser parser = new Parser(calculator);
            String input1 = "5! / 12 A + 9 =";
            List<ICommand> commands = parser.Parse(input1);
            commands.ForEach(command => command.Execute());
            Assert.AreEqual(9, calculator.Result);
        }

        [Test]
        public void ProblemSetTest7()
        {
            // 0.5 1/x * 2 =
            Calculator calculator = new Calculator();
            Parser parser = new Parser(calculator);
            String input1 = "0.5 1/x * 2 =";
            List<ICommand> commands = parser.Parse(input1);
            commands.ForEach(command => command.Execute());
            Assert.AreEqual(4, calculator.Result);
        }

        [Test]
        public void UnsupportedCharacterTest()
        {
            Calculator calculator = new Calculator();
            Parser parser = new Parser(calculator);
            String input = "bh,1 /";
            Assert.IsTrue(parser.ContainsUnsupportedCharacters(input));
        }
        
        [Test]
        public void SupportedCharacterTest()
        {
            Calculator calculator = new Calculator();
            Parser parser = new Parser(calculator);
            String input = " 1 + 2 ";
            Assert.IsFalse(parser.ContainsUnsupportedCharacters(input));
        }

        [Test]
        public void ContainsQuit()
        {
            Calculator calculator = new Calculator();
            Parser parser = new Parser(calculator);
            String input = "2+Q2/";
            Assert.IsTrue(parser.ContainsQuitCommand(input));
        }
    }
}
using System.Collections.Generic;
using ConsoleCalculator.Commands;
using ConsoleCalculator.Operands;
using ConsoleCalculator.Operations;
using NUnit.Framework;

namespace ConsoleCalculator.Tests.CommandTests
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void PushOperandCommandTest()
        {
            Calculator calculator = new Calculator();
            ICommand command = new PushOperandCommand(calculator, 5);
            command.Execute();
            
            Assert.IsTrue(calculator.RootOperand.Equals(new RawOperand(5)));
        }
        
        [Test]
        public void PushOperationCommandTest()
        {
            Calculator calculator = new Calculator();
            ICommand command = new PushOperationCommand(calculator, Calculator.OperationType.Addition);
            command.Execute();
            
            Assert.IsTrue(calculator.RootOperand.Equals(new AdditionOperation()));
        }
        
        [Test]
        public void CalculateCommandTest()
        {
            Calculator calculator = new Calculator();
            List<ICommand> commands = new List<ICommand>();
            commands.Add(new PushOperandCommand(calculator, 5));
            commands.Add(new PushOperationCommand(calculator, Calculator.OperationType.Addition));
            commands.Add(new PushOperandCommand(calculator, 2));
            commands.Add(new CalculateCommand(calculator));
            commands.ForEach(command => command.Execute());
            
            Assert.AreEqual(7, calculator.Result);
        }
        
        [Test]
        public void ClearPreviousNumberCommandTest()
        {
            Calculator calculator = new Calculator();
            List<ICommand> commands = new List<ICommand>();
            commands.Add(new PushOperandCommand(calculator, 5));
            commands.Add(new ClearPreviousNumberCommand(calculator));
            commands.Add(new PushOperandCommand(calculator, 2));
            commands.ForEach(command => command.Execute());
            
            Assert.IsTrue(calculator.RootOperand.Equals(new RawOperand(2)));
        }
        
        [Test]
        public void ClearAllCommandTest()
        {
            Calculator calculator = new Calculator();
            List<ICommand> commands = new List<ICommand>();
            commands.Add(new PushOperandCommand(calculator, 5));
            commands.Add(new PushOperationCommand(calculator, Calculator.OperationType.Addition));
            commands.Add(new PushOperandCommand(calculator, 2));
            commands.Add(new CalculateCommand(calculator));
            commands.Add(new ClearAllCommand(calculator));
            commands.ForEach(command => command.Execute());

            Assert.IsTrue(calculator.RootOperand.Equals(new EmptyOperand()));
        }
    }
}
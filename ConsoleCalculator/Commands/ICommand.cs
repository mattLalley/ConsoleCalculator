using System;
using System.Xml.Xsl;

namespace ConsoleCalculator.Commands
{
    public interface ICommand
    {
        void Execute();
        void Execute(Action<String> error);
    }
}
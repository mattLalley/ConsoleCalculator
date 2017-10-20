namespace ConsoleCalculator.Operands
{
    public interface IOperand
    {
        int PrecedenceLevel { get; }
        double GetValue();
        bool Equals(IOperand operand);
        bool IsEmpty();
    }
}
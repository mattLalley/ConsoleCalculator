namespace ConsoleCalculator
{
    public interface IOperationCommand
    {
        double Value1 { get; set; }
        double Value2 { get; set; }
        
        double Execute();
    }
}
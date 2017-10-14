namespace ConsoleCalculator
{
    public class MultiplicationCommand : IOperationCommand
    {
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Execute()
        {
            return Value1 * Value2;
        }
    }
}
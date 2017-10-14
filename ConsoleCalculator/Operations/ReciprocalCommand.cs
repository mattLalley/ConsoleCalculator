namespace ConsoleCalculator
{
    public class ReciprocalCommand : IOperationCommand
    {
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Execute()
        {
            return 1 / Value1;
        }
    }
}
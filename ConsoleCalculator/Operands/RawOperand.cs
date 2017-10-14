namespace ConsoleCalculator.Operands
{
    public class RawOperand : IOperand
    {
        public RawOperand(double value)
        {
            _value = value;
        }
        private double _value;

        public double GetValue()
        {
            return _value;
        }
    }
}
namespace Price_Calculator.Common
{
    public static class DecimalPrecision
    {
        public static decimal GetTaxAmount(this decimal price, double tax)
        {
            return Math.Round(price * (decimal)tax, 2);
        }
    }
}

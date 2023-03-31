namespace Price_Calculator.Common
{
    public static class DecimalPrecision
    {
        public static decimal GetAmountFromPriceBasedOfRate(this decimal price, double rate)
        {
            return Math.Round(price * (decimal)rate, 2);
        }
    }
}

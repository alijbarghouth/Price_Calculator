namespace Price_Calculator.Common
{
    public static class DecimalPrecision
    {
        public static decimal RoundToTwoPlaces(this decimal price)
        {
            return Math.Round(price, 2);
        }
    }
}

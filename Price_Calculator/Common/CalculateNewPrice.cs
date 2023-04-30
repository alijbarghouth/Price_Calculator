using Price_Calculator.Model;

namespace Price_Calculator.Common
{
    public static class CalculateNewPrice
    {
        public static void SetTotalPriceAfterTheDiscount(this Product product, decimal discount)
        {
            product.Price -= discount;
        }
    }
}

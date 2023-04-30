using Price_Calculator.Model;

namespace Price_Calculator.Common.ProductExtension
{
    public static class ProductExtensionMethods
    {
        public static void SetTotalPriceAfterTheDiscount(this Product product, decimal discount)
        {
            product.Price -= discount;
        }
        public static decimal RoundToTwoPlaces(this decimal price)
        {
            return Math.Round(price, 2);
        }
    }
}

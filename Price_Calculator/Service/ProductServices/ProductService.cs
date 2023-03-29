using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices
{
    public class ProductService
    {
        internal static void GetPriceAfterTax(Product product, double tax)
        {
            Console.WriteLine($"the product price before the tax is {product.Price}");

            decimal taxAmount = Math.Round(product.Price * (decimal) tax,2);

            decimal priceAfterTheTax = product.Price + taxAmount;

            Console.WriteLine($"the product price after the tax = {priceAfterTheTax}");
        }
    }
}

using Price_Calculator.Common.ProductExtension;
using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.TaxService
{
    public class TaxServcie : ITaxServcie
    {
        public decimal GetTaxFromPrice(Product product)
        {
            var tax = product.GetTax();
            Console.WriteLine($"the Tax of the product is {tax.RoundToTwoPlaces()} {product.CurrencyType}");

            return tax;
        }
    }
}
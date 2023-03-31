using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.TaxService
{
    public class TaxServcie : ITaxServcie
    {
        public decimal GetTheTaxFromPrice(Product product)
        {
            var tax = product.GetTheTax();
            Console.WriteLine($"the Tax of the product is {tax}");

            return tax;
        }
    }
}

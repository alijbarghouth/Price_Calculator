using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.TaxService
{
    public class TaxServcie : ITaxServcie
    {

        public void PrintTheProductPriceToTheUser(Product product)
        {
            if(product is null)
            {
                Console.WriteLine("the product must be not null");
                return;
            }
            Console.WriteLine($"the product price before the tax is {product.Price}");

            Console.WriteLine($"the product after the tax is {product.GetTotalPriceAfterTheTax()}");
        }

        
    }
}

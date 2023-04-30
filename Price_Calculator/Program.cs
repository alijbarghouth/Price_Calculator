using Price_Calculator.Service.ProductServices;
using Price_Calculator.Service.ProductServices.DiscountService;
using Price_Calculator.Service.ProductServices.TaxService;
using Price_Calculator.Service.ProductServices.UpcDiscountService;
using Price_Calculator.Utils;

namespace Price_Calculator
{
    public class Program
    {
        private static void Main()
        {
            var product = InputValidator.InputValidation();
            var productService = new ProductService(new TaxServcie(), new DiscountService()
                , new UPCDiscountServcie());

            productService.AllInformationAboutProduct(product);
        }
    }
}
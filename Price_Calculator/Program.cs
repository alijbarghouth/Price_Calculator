using Price_Calculator.Service.ProductServices;
using Price_Calculator.Service.ProductServices.DiscountService;
using Price_Calculator.Service.ProductServices.TaxService;
using Price_Calculator.Service.ProductServices.UpcDiscountService;
using Price_Calculator.Utils;

public class Program
{
    private static void Main(string[] args)
    {
        var product = InputValidator.InputValidation();
        var productService = new ProductService(new TaxServcie(), new DiscountService()
            , new UPCDiscountServcie());

        productService.AllInformationAboutProductPriceAfterTaxAndDiscount(product);
    }
}
using Price_Calculator.Model;
using Price_Calculator.Service.ProductServices;
using Price_Calculator.Service.ProductServices.TaxService;
using Price_Calculator.Utils;

public class Program
{
    private static void Main(string[] args)
    {
        var program = new Program();

        var product = InputValidator.InputValidation();

        program.GetPriceAfterAndBeforeTax(product);
    }

    private  void GetPriceAfterAndBeforeTax(Product product)
    {

        var productService = new ProductService(new TaxServcie());

        productService.AllInformationAboutProductPrice(product);
    }


    

}
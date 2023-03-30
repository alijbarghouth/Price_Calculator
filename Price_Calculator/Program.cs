using Price_Calculator.Model;
using Price_Calculator.Service.ProductServices;
using Price_Calculator.Service.ProductServices.TaxService;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter The Product Name");
        var name = Console.ReadLine();

        Console.WriteLine("Enter The Product Price");
        decimal price;
        while (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid price. Please enter a valid value.");
        }

        Console.WriteLine("Enter The Product Upc");
        int upc;
        while (!int.TryParse(Console.ReadLine(), out upc))
        {
            Console.WriteLine("Invalid UPC. Please enter a valid  value.");
        }

        double tax = 0;
        bool isValidInput = false;
        while (!isValidInput)
        {
            Console.WriteLine("Enter the tax rate:");
            if (double.TryParse(Console.ReadLine(), out tax))
            {
                if (tax >= 0 && tax <= 1)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Tax rate should be between 0 and 100.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal value.");
            }
        }

        var product = new Product
        {
            Name = name,
            Price = price,
            UPC = upc,
            Tax = tax
        };

        GetPriceAfterAndBeforeTax(product);

    
    }

    private static void GetPriceAfterAndBeforeTax(Product product)
    {
        ProductService productService = new(new TaxServcie(product));

        productService.AllInformationAboutProductPrice();
    }




}
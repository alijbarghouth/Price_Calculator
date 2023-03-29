using Price_Calculator.Model;
using Price_Calculator.Service.ProductServices;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Please enter the name, price and upc of the product in the order");
        Product product = new Product
        {
            Name = Console.ReadLine(),
            Price = decimal.Parse(Console.ReadLine()),
            UPC = int.Parse(Console.ReadLine())
        };
        Console.WriteLine("Enter the tax rate:");

        double Tax = double.Parse(Console.ReadLine());

        ProductService.GetPriceAfterTax(product, Tax);
    }




}
using Price_Calculator;
using Price_Calculator.ProductService;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductRepositioning productRepositioning = new ProductRepositioning(new TwentyPercentOff());
        Console.WriteLine($"The Price after Tax is :{productRepositioning.GetTheFinalPriceAfterTax()}");
    }

   
}
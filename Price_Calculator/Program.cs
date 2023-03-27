using Price_Calculator;
using Price_Calculator.ProductService;

internal class Program
{
    private static void Main(string[] args)
    {
        int tax = int.Parse(Console.ReadLine());    
        Console.WriteLine($"The Price after Tax is :{GetTheFinalPriceAfterTax(tax)}");
    }

    private static decimal GetTheFinalPriceAfterTax(int tax)
    {
        Product product = new()
        {
            Name = "Test",
            Price = 20.25m,
            UPC = 10
        };
        Console.WriteLine($"The Price before Tax is :{product.Price}");


        ITAXService taxType = GetTAXType(tax);

        var TotalPrice = product.Price + taxType.TheTaxOnThePrice(product.Price);

        return Math.Round(TotalPrice, 2);
    }

    private static ITAXService GetTAXType(int tax)
    {
        switch (tax)
        {
            case 20:
                return new TwentyPercentOff();
            case 30:
                return new ThirtyPercentOff();
            default:
                return new TenPercentOff();
        }
    }
}
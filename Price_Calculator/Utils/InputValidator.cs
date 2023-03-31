using Price_Calculator.Model;
using Price_Calculator.ValidationInputs;

namespace Price_Calculator.Utils
{
    public static class InputValidator
    {
        private readonly static string stringPattern = @"^[a-zA-Z\s]+$";
        private readonly static string pricePattern = @"^\d+(\.\d{1,2})?$";
        private readonly static string upcPattern = @"^\d+$";
        private readonly static string taxPattern = @"^\d+(\.\d{1,2})?$";

        public static Product InputValidation()
        {
            var name = NameInputValidation();
            var price = PriceInputValidation();
            var upc = UpcInputValidation();
            var tax = TaxInputValidation();
            var product = new Product(name, price, upc, tax);

            return product;
        }
        private static string NameInputValidation()
        {
            Console.WriteLine("Enter The Product Name");

            var name = Console.ReadLine()?.Trim();
            var nameString = name.InputsValidatedUsingRegularExpression(stringPattern);

            return nameString;
        }
        private static int UpcInputValidation()
        {
            Console.WriteLine("Enter The Product Upc");

            var upcInput = Console.ReadLine();
            var upcString = upcInput.InputsValidatedUsingRegularExpression(upcPattern);

            return Convert.ToInt32(upcString);
        }
        private static decimal PriceInputValidation()
        {
            Console.WriteLine("Enter The Product Price");

            var priceInput = Console.ReadLine();
            var stringPrice = priceInput.InputsValidatedUsingRegularExpression(pricePattern);

            return Convert.ToDecimal(stringPrice);
        }
        private static double TaxInputValidation()
        {
            Console.WriteLine("Enter The Product Tax");

            var taxInput = Console.ReadLine();
            var taxDouble = taxInput.InputsValidatedUsingRegularExpression(taxPattern);

            return Convert.ToDouble(taxDouble);
        }
    }
}

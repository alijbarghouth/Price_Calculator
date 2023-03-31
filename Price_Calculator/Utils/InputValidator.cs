using Price_Calculator.Model;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Price_Calculator.Utils
{
    public static class InputValidator
    {
        public static Product InputValidation()
        {
            var name = NameInputValidation();

            var price = PriceInputValidation();

            var upc = UpcInputValidation();

            var tax = TaxInputValidation();

            var product = new Product(name, price, upc, tax);

            return product;
        }
        private static double TaxInputValidation()
        {
            Console.WriteLine("Enter The Product Tax");
            var taxInput = Console.ReadLine();

            string pattern = @"^\d+(\.\d{1,2})?$";
            var taxDouble =  InputsValidatedUsingRegularExpression(taxInput, pattern);
            return Convert.ToDouble(taxDouble);
        }
        private static string NameInputValidation()
        {
            Console.WriteLine("Enter The Product Name");
            var name = Console.ReadLine()?.Trim();

            string pattern = @"^[a-zA-Z\s]+$";
            var nameString = InputsValidatedUsingRegularExpression(name, pattern);

            return nameString;
        }
        private static int UpcInputValidation()
        {
            Console.WriteLine("Enter The Product Upc");
            var upcInput = Console.ReadLine();

            string pattern = @"^\d+$";

            var upcString = InputsValidatedUsingRegularExpression(upcInput, pattern);

            return Convert.ToInt32(upcString);
        }
        private static decimal PriceInputValidation()
        {
            Console.WriteLine("Enter The Product Price");
            var priceInput = Console.ReadLine();

            var PricePattern = @"^\d+(\.\d{1,2})?$";

            var stringPrice =InputsValidatedUsingRegularExpression(priceInput, PricePattern);

            return Convert.ToDecimal(stringPrice);
        }
        private static string InputsValidatedUsingRegularExpression(string input, string pattern)
        {
            var inputString = input.Trim();
            while (string.IsNullOrWhiteSpace(inputString) || !Regex.IsMatch(inputString, pattern))
            {
                Console.WriteLine("Invalid name input. Please enter a non-empty string with any character except white space.");
                inputString = Console.ReadLine();
            }
            return inputString;
        }
    }
}

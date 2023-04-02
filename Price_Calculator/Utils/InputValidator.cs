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
        private readonly static string discountPattern = @"^\d+(\.\d{1,2})?$";

        public static Product InputValidation()
        {
            var name = NameInputValidation();
            var price = PriceInputValidation();
            var upc = UpcInputValidation();
            var tax = TaxInputValidation();
            var discount = DiscountInputValidation();
            var upcDiscount = UpcDiscountInputValidation();
            var upcValue  =UpcValueInputValidation();
            var product = new Product(name, price, upc, tax,discount,upcValue,upcDiscount);

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

            return int.Parse(upcString);
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
        private static double DiscountInputValidation()
        {
            Console.WriteLine("Enter The Product Discount");

            var discountInput = Console.ReadLine();
            var discountDouble = discountInput.InputsValidatedUsingRegularExpression(discountPattern);

            return Convert.ToDouble(discountDouble);
        }
        private static double UpcDiscountInputValidation()
        {
            Console.WriteLine("Enter The Product UPC Discount");

            var upcDiscountInput = Console.ReadLine();
            var discountDouble = upcDiscountInput.InputsValidatedUsingRegularExpression(discountPattern);

            return Convert.ToDouble(discountDouble);
        }
        private static int UpcValueInputValidation()
        {
            Console.WriteLine("Enter The Product UPC value");

            var upcValueInput = Console.ReadLine();
            var upcValueDouble = upcValueInput.InputsValidatedUsingRegularExpression(discountPattern);

            return int.Parse(upcValueDouble);
        }
    }
}

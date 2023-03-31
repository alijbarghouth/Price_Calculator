using System.Text.RegularExpressions;

namespace Price_Calculator.ValidationInputs
{
    public static class Validation
    {
        public static string InputsValidatedUsingRegularExpression(this string input, string pattern)
        {
            var inputString = input.Trim();
            while (string.IsNullOrWhiteSpace(inputString) || !Regex.IsMatch(inputString, pattern))
            {
                Console.WriteLine("Invalid  input. Please enter valid input.");
                inputString = Console.ReadLine();
            }

            return inputString;
        }
    }
}

using Price_Calculator.Common;

namespace Price_Calculator.Model
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int UPC { get; set; }
        public double Tax { get; set; }

        public Product(string name, decimal price, int upc, double tax)
        {
            Name = name;
            Price = price;
            UPC = upc;
            Tax = tax;
        }
        public decimal GetTotalPriceAfterTheTax()
        {
            return Price + Price.GetTaxAmount(Tax);
        }
    }
}

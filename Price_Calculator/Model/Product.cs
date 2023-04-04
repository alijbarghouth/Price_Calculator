using Price_Calculator.Common;

namespace Price_Calculator.Model
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int UPC { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }

        public Product(string name, decimal price, int upc, double tax, double discount)
        {
            Name = name;
            Price = price;
            UPC = upc;
            Tax = tax;
            Discount = discount;
        }
        public decimal GetTotalPriceAfterTaxAndDiscount()
        {
            return Price
                + Price.RoundToTowPlaces()
                - Price.RoundToTowPlaces();
        }
        public decimal GetTheTax()
        {
            var taxRate = (Price * (decimal)Tax);

            return taxRate.RoundToTowPlaces();
        }
      
        public decimal GetTheDiscount()
        {
            var discountRate = (Price * (decimal)Discount);

            return discountRate.RoundToTowPlaces();
        }
        
    }
}

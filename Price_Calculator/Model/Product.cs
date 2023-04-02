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
        public int UPCValue { get; set; }
        public double UPCDiscount { get; set; }

        public Product(string name, decimal price, int upc, double tax, double discount, int uPCValue, double uPCDiscount)
        {
            Name = name;
            Price = price;
            UPC = upc;
            Tax = tax;
            Discount = discount;
            UPCValue = uPCValue;
            UPCDiscount = uPCDiscount;
        }
        public decimal GetTotalPriceAfterTaxAndDiscount()
        {
            return Price
                + Price.GetAmountFromPriceBasedOfRate(Tax)
                - Price.GetAmountFromPriceBasedOfRate(Discount);
        }
        public decimal GetTheTax()
        {
            return Price.GetAmountFromPriceBasedOfRate(Tax);
        }
        public decimal GetTheDiscount()
        {
            return Price.GetAmountFromPriceBasedOfRate(Discount);
        }
        public bool IsUpcIsEqualUpcValue()
        {
            return UPC == UPCValue;
        }
    }
}

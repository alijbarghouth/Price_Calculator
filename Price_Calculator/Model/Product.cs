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
        public bool ApplyDiscountsBeforeTax { get; set; }
        public bool ApplyUpcDiscountsBeforeTax { get; set; }

        public Product(string name, decimal price, int upc, double tax, double discount, int uPCValue, double uPCDiscount, bool applyDiscountsBeforeTax, bool applyUpcDiscountsBeforeTax)
        {
            Name = name;
            Price = price;
            UPC = upc;
            Tax = tax;
            Discount = discount;
            UPCValue = uPCValue;
            UPCDiscount = uPCDiscount;
            ApplyDiscountsBeforeTax = applyDiscountsBeforeTax;
            ApplyUpcDiscountsBeforeTax = applyUpcDiscountsBeforeTax;
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
        public decimal GetDiscountFromUpcDiscount()
        {
            return Price.GetAmountFromPriceBasedOfRate(UPCDiscount);
        }
        public bool IsUpcIsEqualUpcValue()
        {
            return UPC == UPCValue;
        }
    }
}

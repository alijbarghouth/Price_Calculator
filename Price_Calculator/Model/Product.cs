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
        public bool IsApplyDiscountsBeforeTax { get; set; }
        public bool IsApplyUpcDiscountsBeforeTax { get; set; }
        public double PackagingCost { get; set; }
        public double TransportCost { get; set; }
        public bool IsNormalDiscount { get; set; }
        public double Cap { get; set; }

        public Product(string name, decimal price, int upc,
            double tax, double discount, int uPCValue,
            double uPCDiscount, bool applyDiscountsBeforeTax,
            bool applyUpcDiscountsBeforeTax, double transportCost, double packagingCost
            , bool isNormalDiscount, double cap)
        {
            Name = name;
            Price = price;
            UPC = upc;
            Tax = tax;
            Discount = discount;
            UPCValue = uPCValue;
            UPCDiscount = uPCDiscount;
            IsApplyDiscountsBeforeTax = applyDiscountsBeforeTax;
            IsApplyUpcDiscountsBeforeTax = applyUpcDiscountsBeforeTax;
            TransportCost = transportCost;
            PackagingCost = packagingCost;
            IsNormalDiscount = isNormalDiscount;
            Cap = cap;
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
        public decimal GetTotalCost()
        {
            return GetTransportCost() + GetPackagingCost();
        }
        private decimal GetTransportCost()
        {
            return TransportCost >= 1 ? (decimal)TransportCost : Price.GetAmountFromPriceBasedOfRate(TransportCost);
        }
        private decimal GetPackagingCost()
        {
            return PackagingCost >= 1 ? (decimal)PackagingCost : Price.GetAmountFromPriceBasedOfRate(PackagingCost);
        }
        public decimal GetCapFromProductPrice()
        {
            return Cap >= 1 ? (decimal)Cap : Price.GetAmountFromPriceBasedOfRate(Cap); 
        }
    }
}

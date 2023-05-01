using Price_Calculator.Common.ProductExtension;

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
        public bool ApplyUpcDiscountsBeforeTax { get; set; }
        public double PackagingCost { get; set; }
        public double TransportCost { get; set; }
        public bool IsNormalDiscount { get; set; }
        public double Cap { get; set; }

        public Product(string name, decimal price, int upc, double tax, double discount,
            int uPCValue, double uPCDiscount, bool applyUpcDiscountsBeforeTax, double transportCost
            , double packagingCost, bool isNormalDiscount, double cap)
        {
            Name = name;
            Price = price;
            UPC = upc;
            Tax = tax;
            Discount = discount;
            UPCValue = uPCValue;
            UPCDiscount = uPCDiscount;
            ApplyUpcDiscountsBeforeTax = applyUpcDiscountsBeforeTax;
            TransportCost = transportCost;
            PackagingCost = packagingCost;
            IsNormalDiscount = isNormalDiscount;
            Cap = cap;
        }
        public decimal GetTax()
        {
            var taxRate = Price * (decimal)Tax;

            return taxRate.RoundToTwoPlaces();
        }
        public decimal GetDiscount()
        {
            var discountRate = Price * (decimal)Discount;

            return discountRate.RoundToTwoPlaces();
        }
        public decimal GetUPCDiscount()
        {
            var upcDiscountRate = Price * (decimal)UPCDiscount;

            return IsUpcIsEqualUpcValue()
                ? upcDiscountRate.RoundToTwoPlaces()
                : 0;
        }
        private bool IsUpcIsEqualUpcValue()
        {
            return UPC == UPCValue;
        }
        public decimal GetTotalCost()
        {
            return GetTransportCost() + GetPackagingCost();
        }
        private decimal GetTransportCost()
        {
            var transportCost = TransportCost > 1 ? (decimal)TransportCost : Price * (decimal)TransportCost;

            return transportCost.RoundToTwoPlaces();
        }
        private decimal GetPackagingCost()
        {
            var packagingCost = PackagingCost > 1 ? (decimal)PackagingCost : Price * (decimal)PackagingCost;

            return packagingCost.RoundToTwoPlaces();
        }
        public decimal GetCapFromProductPrice()
        {
            var cap = Cap > 1 ? (decimal)Cap : Price * (decimal)Cap;

            return cap.RoundToTwoPlaces();
        }
    }
}

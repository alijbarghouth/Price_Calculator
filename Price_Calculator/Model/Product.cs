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
        public bool ApplyUpcDiscountsBeforeTax { get; set; }

        public Product(string name, decimal price, int upc, double tax, double discount,
            int uPCValue, double uPCDiscount, bool applyUpcDiscountsBeforeTax)
        {
            Name = name;
            Price = price;
            UPC = upc;
            Tax = tax;
            Discount = discount;
            UPCValue = uPCValue;
            UPCDiscount = uPCDiscount;
            ApplyUpcDiscountsBeforeTax = applyUpcDiscountsBeforeTax;
        }
        public decimal GetTax()
        {
            var taxRate = Price *(decimal) Tax;

            return taxRate.RoundToTwoPlaces();
        }
        public decimal GetDiscount()
        {
            var discountRate = Price * (decimal) Discount;

            return discountRate.RoundToTwoPlaces();
        }
        public decimal GetUPCDiscount()
        {
            var upcDiscountRate = Price * (decimal) UPCDiscount;
            
            return IsUpcIsEqualUpcValue() 
                ? upcDiscountRate.RoundToTwoPlaces()
                : 0;
        }
        private bool IsUpcIsEqualUpcValue()
        {
            return UPC == UPCValue;
        }
    }
}

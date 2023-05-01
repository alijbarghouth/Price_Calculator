using Price_Calculator.Common.ProductExtension;
using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.UpcDiscountService
{
    public class UPCDiscountServcie : IUPCDiscountServcie
    {
        public decimal GetUpcDiscountFromPrice(Product product)
        {
            var upcDiscount = product.GetUPCDiscount();
            if (product.ApplyUpcDiscountsBeforeTax)
                product.SetTotalPriceAfterTheDiscount(upcDiscount);

            return upcDiscount;
        }
    }
}
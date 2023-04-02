using Price_Calculator.Common;
using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.UpcDiscountService
{
    public class UPCDiscountServcie : IUPCDiscountServcie
    {
        public decimal GetUpcDiscount(Product product)
        {
            return product.Price.GetAmountFromPriceBasedOfRate(product.UPCDiscount);
        }
    }
}

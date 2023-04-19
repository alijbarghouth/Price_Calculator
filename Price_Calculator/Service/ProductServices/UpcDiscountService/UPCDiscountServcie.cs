using Price_Calculator.Common;
using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.UpcDiscountService
{
    public class UPCDiscountServcie : IUPCDiscountServcie
    {
        public decimal GetUpcDiscountFromPrice(Product product)
        {
            return product.GetUPCDiscount();
        }
    }
}

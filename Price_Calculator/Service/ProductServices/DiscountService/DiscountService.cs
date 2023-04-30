using Price_Calculator.Common.ProductExtension;
using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.DiscountService
{
    public class DiscountService : IDiscountService
    {
        public decimal GetDiscountFromPrice(Product product)
        {
            var discount = product.GetDiscount();
            if (!product.IsNormalDiscount)
                product.SetTotalPriceAfterTheDiscount(discount);

            return discount;
        }
    }
}
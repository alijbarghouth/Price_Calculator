using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.DiscountService
{
    public class DiscountService : IDiscountService
    {
        public decimal GetTheDiscountFromPrice(Product product)
        {
            var discount = product.GetTheDiscount();

            return discount;
        }
    }
}

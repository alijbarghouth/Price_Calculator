using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.DiscountService
{
    public class DiscountService : IDiscountService
    {

        public decimal GetDiscountFromPrice(Product product)
        {
            return product.GetDiscount();
        }
    }
}

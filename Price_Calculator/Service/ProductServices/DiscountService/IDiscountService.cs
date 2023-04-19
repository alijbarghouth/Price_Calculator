using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.DiscountService
{
    public interface IDiscountService
    {
        decimal GetDiscountFromPrice(Product product);
    }
}

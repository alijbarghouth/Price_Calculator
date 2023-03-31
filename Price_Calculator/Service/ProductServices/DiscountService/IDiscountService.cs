using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.DiscountService
{
    public interface IDiscountService
    {
        decimal GetTheDiscountFromPrice(Product product);
    }
}

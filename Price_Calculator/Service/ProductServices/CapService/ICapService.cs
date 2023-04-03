using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.CapService
{
    public interface ICapService
    {
        decimal GetCapFromPrice(Product product);
    }
}

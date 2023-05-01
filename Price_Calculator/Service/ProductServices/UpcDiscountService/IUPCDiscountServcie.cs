using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.UpcDiscountService
{
    public interface IUPCDiscountServcie
    {
        decimal GetUpcDiscountFromPrice(Product product);
    }
}

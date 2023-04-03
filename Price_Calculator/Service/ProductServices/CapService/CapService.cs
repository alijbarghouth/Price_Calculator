using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.CapService
{
    public class CapService : ICapService
    {
        public decimal GetCapFromPrice(Product product)
        {
            return product.GetCapFromProductPrice();
        }
    }
}

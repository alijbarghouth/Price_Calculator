using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.CostService
{
    public class CostService : ICostService
    {
        public decimal GetTotalCostromPrice(Product product)
        {
            return product.GetTotalCost();
        }
    }
}

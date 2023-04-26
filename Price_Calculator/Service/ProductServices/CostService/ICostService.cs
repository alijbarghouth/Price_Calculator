using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.CostService
{
    public interface ICostService
    {
        decimal GetTotalCustomTaxes(Product product);
    }
}

using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.TaxService
{
    public interface ITaxServcie
    {
        decimal GetTheTaxFromPrice(Product product);
    }
}

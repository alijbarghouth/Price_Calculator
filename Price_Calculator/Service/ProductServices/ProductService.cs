using Price_Calculator.Model;
using Price_Calculator.Service.ProductServices.TaxService;

namespace Price_Calculator.Service.ProductServices
{
    public class ProductService
    {
        private readonly ITaxServcie _taxServcie;

        public ProductService(ITaxServcie taxServcie)
        {
            _taxServcie = taxServcie;
        }

        public void GetPriceAfterTax()
        {
           _taxServcie.PrintTheProductPriceToTheUser();
        }

        

    }
}

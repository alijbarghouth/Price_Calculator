using Price_Calculator.Model;
using Price_Calculator.Service.ProductServices.CostService;
using Price_Calculator.Service.ProductServices.DiscountService;
using Price_Calculator.Service.ProductServices.TaxService;
using Price_Calculator.Service.ProductServices.UpcDiscountService;

namespace Price_Calculator.Service.ProductServices
{
    public class ProductService
    {
        private readonly ITaxServcie _taxServcie;
        private readonly IDiscountService _discountService;
        private readonly IUPCDiscountServcie _uPCDiscountServcie;
        private readonly ICostService _costService;

        public ProductService(ITaxServcie taxServcie
            , IDiscountService discountService
            , IUPCDiscountServcie uPCDiscountServcie
            , ICostService costService)
        {
            _taxServcie = taxServcie;
            _discountService = discountService;
            _uPCDiscountServcie = uPCDiscountServcie;
            _costService = costService;
        }

        public void AllInformationAboutProduct(Product product)
        {
            if (product is null)
            {
                Console.WriteLine("the product must be not null");
                return;
            }

            Console.WriteLine($"The product price before any calcalation is {product.Price}");
            Console.WriteLine($"the  discount of the price is  {GetTotalDiscount(product)}");
            Console.WriteLine($"The product After calcalation is {FinalPrice(product)}");
        }
        private decimal FinalPrice(Product product)
        {
            var totalTaxes = GetTotalTaxes(product);

            if (product.ApplyUpcDiscountsBeforeTax)
                return product.Price + totalTaxes - _discountService.GetDiscountFromPrice(product);

            return product.Price + totalTaxes - GetTotalDiscount(product);
        }
        private decimal GetTotalDiscount(Product product)
        {
            return _uPCDiscountServcie.GetUpcDiscountFromPrice(product)
                + _discountService.GetDiscountFromPrice(product);
        }
        private decimal GetTotalTaxes(Product product)
        {
            return _taxServcie.GetTaxFromPrice(product)
                + _costService.GetTotalCustomTaxes(product);
        }
    }
}


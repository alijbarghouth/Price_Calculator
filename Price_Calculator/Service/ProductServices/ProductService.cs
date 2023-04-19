using Price_Calculator.Model;
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

        public ProductService(ITaxServcie taxServcie
            , IDiscountService discountService
            , IUPCDiscountServcie uPCDiscountServcie)
        {
            _taxServcie = taxServcie;
            _discountService = discountService;
            _uPCDiscountServcie = uPCDiscountServcie;
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
            var tax = _taxServcie.GetTaxFromPrice(product);

            if (product.ApplyUpcDiscountsBeforeTax)
                return product.Price + tax - _discountService.GetDiscountFromPrice(product);

            return product.Price + tax - GetTotalDiscount(product);
        }
        private decimal GetTotalDiscount(Product product)
        {
            return _uPCDiscountServcie.GetUpcDiscountFromPrice(product)
                + _discountService.GetDiscountFromPrice(product);
        }
    }
}

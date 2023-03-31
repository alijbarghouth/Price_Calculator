using Price_Calculator.Model;
using Price_Calculator.Service.ProductServices.DiscountService;
using Price_Calculator.Service.ProductServices.TaxService;

namespace Price_Calculator.Service.ProductServices
{
    public class ProductService
    {
        private readonly ITaxServcie _taxServcie;
        private readonly IDiscountService _discountService;

        public ProductService(ITaxServcie taxServcie, IDiscountService discountService)
        {
            _taxServcie = taxServcie;
            _discountService = discountService;
        }

        public void AllInformationAboutProductPriceAfterTaxAndDiscount(Product product)
        {
            if (product is null)
            {
                Console.WriteLine("the product must be not null");
                return;
            }

            Console.WriteLine($"The product price before any calcalation is {product.Price}");
            Console.WriteLine($"The product After Tax And Discount is {PriceAfterTaxAndDiscount(product)}");
        }

        private decimal PriceAfterTaxAndDiscount(Product product)
        {
            var price = product.Price;
            var tax = _taxServcie.GetTheTaxFromPrice(product);
            var discount = _discountService.GetTheDiscountFromPrice(product);

            return price + tax - discount ;
        }
    }
}

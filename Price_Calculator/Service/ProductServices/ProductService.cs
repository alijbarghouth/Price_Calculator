using Price_Calculator.Common;
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

        public void AllInformationAboutProductPriceAfterTaxAndDiscount(Product product)
        {
            if (product is null)
            {
                Console.WriteLine("the product must be not null");
                return;
            }

            Console.WriteLine($"The product price before any calcalation is {product.Price}");
            Console.WriteLine($"the  discount of the price is  {GetTotalDiscount(product)}");
            Console.WriteLine($"The product After Tax And Discount is {PriceAfterTaxAndDiscount(product)}");
        }

        private decimal PriceAfterTaxAndDiscount(Product product)
        {
            var price = product.Price;
            var tax = _taxServcie.GetTheTaxFromPrice(product);
            var discount = _discountService.GetTheDiscountFromPrice(product);
            var totalPrice = price + tax - discount;

            return product.IsUpcIsEqualUpcValue() 
                ? totalPrice - _uPCDiscountServcie.GetUpcDiscount(product)
                : totalPrice ;
        }
        private decimal GetTotalDiscount(Product product)
        {
            var totalDiscount = _discountService.GetTheDiscountFromPrice(product);

            return product.IsUpcIsEqualUpcValue() 
                ? totalDiscount + _uPCDiscountServcie.GetUpcDiscount(product)
                : totalDiscount ;
        }
    }
}

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
            var totalDiscount = GetTotalDiscount(product);
            Console.WriteLine($"the  discount of the price is  {totalDiscount}");
            Console.WriteLine($"The product After Tax And Discount is {PriceAfterTaxAndDiscount(product)}");
        }

        private decimal PriceAfterTaxAndDiscount(Product product)
        {
            var price = product.Price;
            var tax = _taxServcie.GetTheTaxFromPrice(product);
            var discount = _discountService.GetTheDiscountFromPrice(product);
            var totalPrice = price + tax - discount;

            return totalPrice;
        }
        private decimal GetTotalDiscount(Product product)
        {
            return product.IsUpcIsEqualUpcValue() 
                ? _uPCDiscountServcie.GetUpcDiscount(product) + _discountService.GetTheDiscountFromPrice(product)
                : _discountService.GetTheDiscountFromPrice(product);
        }
    }
}

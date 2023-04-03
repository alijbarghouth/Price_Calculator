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
        private  decimal _taxAnCost;
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
            Console.WriteLine($"The product After Tax And Discount is {PriceAfterTaxAndDiscountAndCosts(product)}");
        }

        private decimal PriceAfterTaxAndDiscountAndCosts(Product product)
        {
            var taxAndCost = _taxAnCost;
            var totalPrice = GetTotalPrice(product, taxAndCost) ;

            return totalPrice;
        }
        private decimal GetTaxAndCost(Product product)
        {
            return _taxServcie.GetTheTaxFromPrice(product)
                + _costService.GetTotalCostromPrice(product);
        }
        private decimal GetTotalPrice(Product product, decimal taxAndCost)
        {
            var priceWithTax = product.Price + taxAndCost;

            if(product.IsApplyDiscountsBeforeTax && product.IsApplyUpcDiscountsBeforeTax)
                return priceWithTax;
            else if ((product.IsApplyDiscountsBeforeTax || !product.IsNormalDiscount) && !product.IsApplyUpcDiscountsBeforeTax)
                return priceWithTax - _uPCDiscountServcie.GetUpcDiscount(product);
            else if(!product.IsApplyDiscountsBeforeTax && product.IsApplyUpcDiscountsBeforeTax)
                return priceWithTax - _discountService.GetTheDiscountFromPrice(product);
            else
                return priceWithTax - _discountService.GetTheDiscountFromPrice(product)
                    -_uPCDiscountServcie.GetUpcDiscount(product);
        }
        private decimal GetTotalDiscount(Product product)
        {
            if (!product.IsNormalDiscount)
                _taxAnCost = GetTaxAndCost(product);
            if (product.IsApplyUpcDiscountsBeforeTax)
                return product.IsUpcIsEqualUpcValue()
                    ? _uPCDiscountServcie.GetUpcDiscount(product) + _discountService.GetTheDiscountFromPrice(product)
                    : _discountService.GetTheDiscountFromPrice(product);
            else 
                return product.IsUpcIsEqualUpcValue()
                    ? _discountService.GetTheDiscountFromPrice(product) + _uPCDiscountServcie.GetUpcDiscount(product)
                    : _discountService.GetTheDiscountFromPrice(product);

        }
    }
}

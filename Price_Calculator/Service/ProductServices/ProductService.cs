using Price_Calculator.Model;
using Price_Calculator.Service.ProductServices.CapService;
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
        private readonly ICapService _capService;
        private  decimal _taxAndCost;

        public ProductService(ITaxServcie taxServcie
            , IDiscountService discountService
            , IUPCDiscountServcie uPCDiscountServcie
            , ICostService costService
            , ICapService capService)
        {
            _taxServcie = taxServcie;
            _discountService = discountService;
            _uPCDiscountServcie = uPCDiscountServcie;
            _costService = costService;
            _capService = capService;
        }

        public void AllInformationAboutProductPriceAfterTaxAndDiscount(Product product)
        {
            if (product is null)
            {
                Console.WriteLine("the product must be not null");
                return;
            }
            Console.WriteLine($"The product price before any calcalation is {product.Price}{product.CurrencyType}");
            var discount = GetTotalDiscount(product);
            var theLessDiscount = GetDiscount(product,discount);
            Console.WriteLine($"the  discount of the price is  {theLessDiscount}{product.CurrencyType}");
            Console.WriteLine($"The product After Tax And Discount is {PriceAfterTaxAndDiscountAndCosts(product,discount)} {product.CurrencyType}");
        }
        private decimal GetDiscount(Product product, decimal discount)
        {
            var capDiscount = _capService.GetCapFromPrice(product);
            
            return discount < capDiscount ? discount : capDiscount;
        }
        private decimal PriceAfterTaxAndDiscountAndCosts(Product product ,decimal totalDiscount)
        {
            var capDiscount = _capService.GetCapFromPrice(product);
            
            if (totalDiscount > capDiscount)
                return product.Price + GetTaxAndCost(product) - capDiscount;

            var totalPrice = GetTotalPrice(product) ;

            return totalPrice;
        }
        private decimal GetTaxAndCost(Product product)
        {
            return _taxServcie.GetTheTaxFromPrice(product)
                + _costService.GetTotalCostromPrice(product);
        }
        private decimal GetTotalPrice(Product product)
        {
            var priceWithTax = product.Price + _taxServcie.GetTheTaxFromPrice(product);

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
                _taxAndCost = GetTaxAndCost(product);
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

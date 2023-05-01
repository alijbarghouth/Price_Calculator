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
        private decimal _taxAmount;
        private decimal _discountAmount;
        private decimal _price;
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
            _price = product.Price;
            PrintFinalPrice(product);
        }
        private void PrintFinalPrice(Product product)
        {
            Console.WriteLine($"The product price before any calcalation is {product.Price} {product.CurrencyType}");
            if (product.IsNormalDiscount)
            {
                _discountAmount = GetTotalDiscount(product);
                _discountAmount = GetDiscount(product, _discountAmount);
                Console.WriteLine($"the  discount of the price is  {_discountAmount} {product.CurrencyType}");
                _taxAmount = GetTotalTaxes(product);
            }
            else
            {
                _taxAmount = GetTotalTaxes(product);
                _discountAmount = GetTotalDiscount(product);
                _discountAmount = GetDiscount(product, _discountAmount);
                Console.WriteLine($"the  discount of the price is  {_discountAmount} {product.CurrencyType}");
            }
            Console.WriteLine($"The product After calcalation is {FinalPrice(_discountAmount)} {product.CurrencyType}");
        }
        private static decimal GetDiscount(Product product, decimal discount)
        {
            var capDiscount = product.GetCapFromProductPrice();

            return discount < capDiscount ? discount : capDiscount;
        }
        private decimal FinalPrice(decimal discount) => _price + _taxAmount - discount;

        private decimal GetTotalDiscount(Product product)
        {
            if (product.IsNormalDiscount)
                return _uPCDiscountServcie.GetUpcDiscountFromPrice(product) + _discountService.GetDiscountFromPrice(product);

            return _discountService.GetDiscountFromPrice(product) + _uPCDiscountServcie.GetUpcDiscountFromPrice(product);
        }
        private decimal GetTotalTaxes(Product product)
            => _taxServcie.GetTaxFromPrice(product) + product.GetTotalCost();
    }
}
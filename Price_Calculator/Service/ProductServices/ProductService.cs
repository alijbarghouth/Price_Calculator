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
        private  decimal _taxAmount;
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
            if (product.IsNormalDiscount)
            {
                Console.WriteLine($"the  discount of the price is  {GetTotalDiscount(product)}");
                _taxAmount = GetTotalTaxes(product);
                Console.WriteLine($"The product After calcalation is {FinalPrice(product)}");
            }
            else
            {
                _taxAmount = GetTotalTaxes(product);
                Console.WriteLine($"the  discount of the price is  {GetTotalDiscount(product)}");
                Console.WriteLine($"The product After calcalation is {FinalPrice(product)}");
            }
        }
        private decimal FinalPrice(Product product)
        {
            if (!product.IsNormalDiscount)
                return product.Price + _taxAmount - _uPCDiscountServcie.GetUpcDiscountFromPrice(product);

            if (product.ApplyUpcDiscountsBeforeTax)
                return product.Price + _taxAmount - _discountService.GetDiscountFromPrice(product);

            return product.Price + _taxAmount - GetTotalDiscount(product);
        }
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


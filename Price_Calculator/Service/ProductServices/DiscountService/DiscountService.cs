using Price_Calculator.Common;
using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.DiscountService
{
    public class DiscountService : IDiscountService
    {
        public decimal GetTheDiscountFromPrice(Product product)
        {
            var discount = product.GetTheDiscount();
            if (product.ApplyDiscountsBeforeTax)
                SetTotalPriceAfterTheDiscount(product);

            return discount;
        }
        private void SetTotalPriceAfterTheDiscount(Product product)
        {
            product.Price -= product.Price.GetAmountFromPriceBasedOfRate(product.Discount);
        }
    }
}

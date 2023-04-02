using Price_Calculator.Common;
using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.UpcDiscountService
{
    public class UPCDiscountServcie : IUPCDiscountServcie
    {
        public decimal GetUpcDiscount(Product product)
        {
            var upcDiscount = product.Price.GetAmountFromPriceBasedOfRate(product.UPCDiscount);
            SetTotalPriceAfterTheDiscount(product);

            return upcDiscount;
        }
        private void SetTotalPriceAfterTheDiscount(Product product)
        {
            product.Price -= product.Price.GetAmountFromPriceBasedOfRate(product.UPCDiscount);
        }
    }
}

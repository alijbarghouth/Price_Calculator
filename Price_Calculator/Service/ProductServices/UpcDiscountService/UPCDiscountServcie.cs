using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.UpcDiscountService
{
    public class UPCDiscountServcie : IUPCDiscountServcie
    {
        public decimal GetUpcDiscountFromPrice(Product product)
        {
            var upcDiscount = product.GetUPCDiscount();
            if (product.ApplyUpcDiscountsBeforeTax)
                SetTotalPriceAfterTheDiscount(product);

            return upcDiscount;
        }
        private static void SetTotalPriceAfterTheDiscount(Product product)
        {
            product.Price -= product.GetUPCDiscount();
        }
    }
}

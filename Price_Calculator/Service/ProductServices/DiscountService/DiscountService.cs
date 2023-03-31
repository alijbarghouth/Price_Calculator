using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.DiscountService
{
    public class DiscountService : IDiscountService
    {
        public decimal GetTheDiscountFromPrice(Product product)
        {
            var discount = product.GetTheDiscount();
            Console.WriteLine($"the  discount of the price is  {discount}");

            return discount;
        }
    }
}

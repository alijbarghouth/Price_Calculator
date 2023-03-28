using Price_Calculator.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator
{
    public class ProductRepositioning
    {
        private readonly ITAXService _taxService;

        public ProductRepositioning(ITAXService taxService)
        {
            _taxService = taxService;
        }

        public  decimal GetTheFinalPriceAfterTax()
        {
            Product product = new()
            {
                Name = "Test",
                Price = 20.25m,
                UPC = 10
            };
            Console.WriteLine($"The Price before Tax is :{product.Price}");


            var TotalPrice = product.Price + _taxService.TheTaxOnThePrice(product.Price);

            return Math.Round(TotalPrice, 2);
        }

        
    }
}

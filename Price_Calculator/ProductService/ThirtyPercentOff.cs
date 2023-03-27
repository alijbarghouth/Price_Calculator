using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator.ProductService
{
    public class ThirtyPercentOff : ITAXService
    {
        public decimal TheTaxOnThePrice(decimal price)
        {
            return price * (decimal) 0.3;
        }
    }
}

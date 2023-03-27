using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator.ProductService
{
    public interface ITAXService
    {
        decimal TheTaxOnThePrice(decimal price);
    }
}

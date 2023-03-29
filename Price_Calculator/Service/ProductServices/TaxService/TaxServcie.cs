using Price_Calculator.Model;

namespace Price_Calculator.Service.ProductServices.TaxService
{
    public class TaxServcie : ITaxServcie
    {
        private readonly Product _product;
        public TaxServcie(Product product)
        {
            _product = product;
        }
        public void PrintTheProductPriceToTheUser()
        {
<<<<<<< HEAD
            if(_product is null)
            {
                Console.WriteLine("the product must be not null");
=======
            if (_product is null)
            {
                Console.WriteLine("the product is null");
>>>>>>> 5ad920379c7d34298beb508d5274e5bc80c17f82
                return;
            }
            Console.WriteLine($"the product price before the tax is {_product.Price}");

            Console.WriteLine($"the product after the tax is {GetTotalPriceAfterTheTax()}");
        }

        private decimal GetTotalPriceAfterTheTax()
        {
            return _product.Price + GetTaxAmount();
        }
        private decimal GetTaxAmount()
        {
            return Math.Round(_product.Price * (decimal)_product.Tax, 2);
        }
    }
}

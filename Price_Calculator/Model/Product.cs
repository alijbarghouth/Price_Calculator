namespace Price_Calculator.Model
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int UPC { get; set; }
        public double Tax { get; set; }

        public Product(string name, decimal price, int uPC, double tax)
        {
            Name = name;
            Price = price;
            UPC = uPC;
            Tax = tax;
        }
    }
}

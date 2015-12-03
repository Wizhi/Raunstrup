namespace Raunstrup.Domain
{
    public class OrderLine
    {
        public Product Product { get; private set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public OrderLine(Product item, int quantity, decimal unitPrice)
        {
            Product = item;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public OrderLine(Product item, int quantity) : this(item, quantity, item.SalesPrice) { }

        public Product GetProduct()
        {
            return Product;
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public decimal GetTotal()
        {
            return UnitPrice * Quantity;
        }
    }
}

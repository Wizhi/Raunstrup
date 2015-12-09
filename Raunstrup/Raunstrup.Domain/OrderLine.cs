namespace Raunstrup.Domain
{
    public class OrderLine
    {
        private int _id;

        public virtual int Id
        {
            get { return _id; }
            set
            {
                if (_id == default(int))
                {
                    // TODO: Handle object apparently already being persisted.
                }

                _id = value;
            }
        }

        public Product Product { get; private set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get;  set; }
        public decimal SubTotal { get { return UnitPrice * Quantity; } }

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
    }
}

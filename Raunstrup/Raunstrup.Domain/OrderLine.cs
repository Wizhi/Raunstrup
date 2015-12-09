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

        public OrderLine(Product item, int quantity)
        {
            Product = item;
            Quantity = quantity;
            UnitPrice = item.SalesPrice;
        }

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

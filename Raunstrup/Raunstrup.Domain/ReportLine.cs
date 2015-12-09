namespace Raunstrup.Domain
{
    public class ReportLine
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

        public Product Item { get; private set; }
        public int Quantity { get; private set; }

        public ReportLine(Product item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
        public Product GetLineItem()
        {
            return Item;
        }

        public int GetQuantity()
        {
            return Quantity;
        }
    }
}

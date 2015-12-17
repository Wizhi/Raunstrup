using System;

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

        public Product Product { get; private set; }
        public int Quantity { get; set; }

        public ReportLine(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}

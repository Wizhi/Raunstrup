using System;
using System.Collections.Generic;

namespace Raunstrup.Core.Domain
{
    public class Draft
    {
        public readonly Customer Customer;

        private int _id;
        private readonly IList<OrderLine> _orderLines = new List<OrderLine>();

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != default(int))
                {
                    // TODO: Handle object apparently already being persisted.
                }

                _id = value;
            }
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Employee ResponsiblEmployee { get; set; }

        public Draft(Customer customer)
        {
            Customer = customer;

            CreationDate = DateTime.Now;
            StartDate = DateTime.Now;
            // TODO: Consider how long the "buffer period" should be.
            EndDate = DateTime.Now.AddDays(7);
        }

        public void AddOrderLine(Product item, int quantity)
        {
            _orderLines.Add(new OrderLine(item,quantity));
        }

        public IList<OrderLine> GetOrderLines()
        {
            return _orderLines;
        }
    }
}

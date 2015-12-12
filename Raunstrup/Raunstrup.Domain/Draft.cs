using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Raunstrup.Domain
{
    public class Draft
    {
        private int _id;
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate;

        public virtual int Id
        {
            get { return _id; }
            set
            {
                if (_id != default(int))
                {
                    // TODO: Handle object apparently already being persisted.
                    throw new Exception("Object ID is already set");
                }

                _id = value;
            }
        }

        public virtual DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                if (value < _endDate)
                {
                    _startDate = value;
                }
                else
                {
                    throw new Exception("Start date have to be earlier than end date");
                }
            }
        }

        public virtual DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                if (value > _startDate)
                {
                    _endDate = value;
                }
                else
                {
                    throw new Exception("End date have to be later than start date");
                }
            }
        }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual Employee ResponsiblEmployee { get; set; }

        public virtual DateTime CreationDate { get; private set; }

        public virtual Customer Customer { get; private set; }

        public double DiscountPercentage { get; set; }

        public decimal Total { get { return OrderLines.Sum(x => x.SubTotal); } }

        public virtual IList<OrderLine> OrderLines { get; private set; }
        
        public Draft(Customer customer)
        {
            Customer = customer;
            CreationDate = DateTime.Now;
            EndDate = _startDate.AddDays(7);
            DiscountPercentage = 0;
            OrderLines = new List<OrderLine>();
        }

        public void AddOrderLine(Product item, int quantity)
        {
            AddOrderLine(item, quantity, item.SalesPrice);
        }

        public void AddOrderLine(Product item, int quantity, decimal pricePerUnit)
        {
            OrderLines.Add(new OrderLine(item, quantity) { UnitPrice = pricePerUnit });
        }

        public void RemoveOrderLine(OrderLine line)
        {
            OrderLines.Remove(line);
        }
        
        //TODO: This need to be removed, is still there for compability
        public IList<OrderLine> GetOrderLines()
        {
            return OrderLines;
        }
    }
}

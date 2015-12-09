using System;
using System.Collections.Generic;

namespace Raunstrup.Domain
{
    public class Draft
    {
        private int _id;
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate;
        // TODO: Investigate whether we use C# 6. How the hell am I not sure about that?
        private readonly IList<OrderLine> _orderLines = new List<OrderLine>();

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

        public virtual double Discount { get; set; }

        public virtual Employee ResponsiblEmployee { get; set; }

        public virtual DateTime CreationDate { get; }

        public virtual Customer Customer { get; }

        public virtual IList<OrderLine> OrderLines
        {
            get { return _orderLines; }
        }

        public Draft()
        {
            CreationDate = DateTime.Now;
            EndDate = _startDate.AddDays(7);
            Discount = 0;
        }

        public Draft(Customer customer)
            : this()
        {
            Customer = customer;
        }

        public void AddOrderLine(Product item, int quantity)
        {
            AddOrderLine(item, quantity, item.SalesPrice);
        }

        public void AddOrderLine(Product item, int quantity, decimal pricePerUnit)
        {
            _orderLines.Add(new OrderLine(item, quantity) { UnitPrice = pricePerUnit });
        }

        //TODO: This need to be removed, is still there for compability
        public IList<OrderLine> GetOrderLines()
        {
            return _orderLines;
        }
    }
}

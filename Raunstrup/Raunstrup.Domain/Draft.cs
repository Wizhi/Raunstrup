using System;
using System.Collections.Generic;

namespace Raunstrup.Domain
{
    public class Draft
    {
        private int _id;
        private DateTime _startDate;
        private DateTime _endDate;
        private readonly IList<OrderLine> _orderLines;

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
                //TODO: Test to see if compareTo behaves correctly 1
                if (value.CompareTo(EndDate) <= 0)
                {
                    _startDate = value;
                }
                else
                {
                    //throw new Exception("Start date have to be earlier than end date");
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
                if (value.CompareTo(StartDate) >= 0)
                {
                    _endDate = value;
                }
                else
                {
                    //TODO: Test to see if compareTo behaves correctly 2
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
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(7);
        }

        public Draft(Customer customer)
            : this()
        {
            Customer = customer;
        }

        public void AddOrderLine(Product item, int quantity)
        {
            OrderLines.Add(new OrderLine(item,quantity));
        }

        //TODO: This need to be removed, is still there for compability
        public IList<OrderLine> GetOrderLines()
        {
            return OrderLines;
        }
    }
}

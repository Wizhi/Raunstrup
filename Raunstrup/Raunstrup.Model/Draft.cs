using System;
using System.Collections.Generic;

namespace Raunstrup.Model
{
    public class Draft
    {

        private int _id;

        public int Id
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

        private DateTime _startDate;

        public DateTime StartDate
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

        private DateTime _endDate;

        public DateTime EndDate
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

        public string Title { get; set; }

        public string Description { get; set; }

        public Employee ResponsiblEmployee { get; set; }

        public readonly DateTime CreationDate;

        public readonly Customer Customer;

        public readonly IList<OrderLine> OrderLines = new List<OrderLine>();


        public Draft(Customer customer)
        {
            Customer = customer;

            CreationDate = DateTime.Now;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(7);
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

using System;
using System.Collections.Generic;
using System.Runtime.Remoting;

namespace Raunstrup.Core.Domain
{
    public class Draft
    {
        private int _id = -1;
        private Customer _customer;
        private Employee _responsiblEmployee;
        private string _title;
        private string _description;
        private DateTime _createDate;
        private DateTime _startDate;
        private DateTime _endDate;
        private List<OrderLine> _orderLines = new List<OrderLine>();

        public Draft(Customer customer, string title, Employee responsibleEmployee)
        {
            _customer = customer;
            _title = title;
            _responsiblEmployee = responsibleEmployee;
            _createDate = DateTime.Now;
            _startDate = DateTime.Now;
            _endDate = DateTime.Now;
            _endDate = _endDate.AddDays(7);
        }

        public void SetResponsibleEmployee(Employee responsibleEmployee)
        {
            _responsiblEmployee = responsibleEmployee;
        }

        public void ChangeTitle(string title)
        {
            _title = title;
        }

        public void ChangeDescription(string description)
        {
            _description = description;
        }
        public void SetId(int id)
        {
            if (_id == -1)
            {
                _id = id;
            }
            else
            {
                throw new Exception("_id has already been set");
            }
        }
        public List<OrderLine> GetOrderLines()
        {
            return _orderLines;
        }

        public void SetStartDate(DateTime startDate)
        {
            _startDate = startDate;
        }

        public void SetEndDate(DateTime endDate)
        {
            _endDate = endDate;
        }
        public void AddOrderLine(Product item, int quantity)
        {
            _orderLines.Add(new OrderLine(item,quantity));
        }
    }
}

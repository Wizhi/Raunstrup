using System;
using System.Collections.Generic;

namespace Raunstrup.Domain.ViewObjects
{
    public class ReadOnlyDraft
    {
        private readonly Draft _draft;

        public string Title
        {
            get { return _draft.Title; }
        }

        public string Description
        {
            get { return _draft.Description; }
        }

        public DateTime StartDate
        {
            get { return _draft.StartDate; }
        }

        public DateTime EndDate
        {
            get { return _draft.EndDate; }
        }

        public DateTime CreationDate
        {
            get { return _draft.CreationDate; }
        }

        public int Id
        {
            get { return _draft.Id; }
        }

        public ReadOnlyDraft(Draft draft)
        {
            _draft = draft;
        }

        public ReadOnlyEmployee ResponsiblEmployee
        {
            get { return new ReadOnlyEmployee(_draft.ResponsiblEmployee);}
        }

        public ReadOnlyCustomer Customer
        {
            get { return new ReadOnlyCustomer(_draft.Customer);}
        }

        public IList<ReadOnlyOrderLine> OrderLines
        {
            get
            {
                IList<OrderLine> originaLines = _draft.OrderLines;
                IList<ReadOnlyOrderLine> returnLines = new List<ReadOnlyOrderLine>();
                foreach (var line in originaLines)
                {
                    returnLines.Add(new ReadOnlyOrderLine(line));
                }
                return returnLines;
            }
        } 
    }
}

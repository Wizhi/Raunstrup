using System;
using System.Collections.Generic;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Ghost
{
    class DraftGhost : Draft
    {
        private readonly Lazy<IList<OrderLine>> _orderLines;
        private readonly DateTime _creationDate;

        public DraftGhost(Customer customer, DateTime creationDate, Func<IList<OrderLine>> orderLines) 
            : base(customer)
        {
            _orderLines = new Lazy<IList<OrderLine>>(orderLines);
            _creationDate = creationDate;
        }

        public override DateTime CreationDate
        {
            get { return _creationDate; }
        }

        public override IList<OrderLine> OrderLines { get { return _orderLines.Value; } }
    }
}

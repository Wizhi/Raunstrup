using System;
using System.Collections.Generic;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Ghost
{
    class DraftGhost : Draft
    {
        private readonly Lazy<IList<OrderLine>> _orderLines;

        public DraftGhost(Customer customer, Func<IList<OrderLine>> orderLines) 
            : base(customer)
        {
            _orderLines = new Lazy<IList<OrderLine>>(orderLines);
        }

        public override IList<OrderLine> OrderLines { get { return _orderLines.Value; } }
    }
}

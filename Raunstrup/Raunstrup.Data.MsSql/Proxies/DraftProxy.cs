using System;
using System.Collections.Generic;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Proxies
{
    class DraftProxy : Draft
    {
        private readonly Lazy<Draft> _real;

        public override int Id { get { return _real.Value.Id; } }
        public override DateTime StartDate { get { return _real.Value.StartDate; } }
        public override DateTime EndDate { get { return _real.Value.EndDate; } }
        public override string Title { get { return _real.Value.Title; } }
        public override string Description { get { return _real.Value.Description; } }
        public override Employee ResponsiblEmployee { get { return _real.Value.ResponsiblEmployee; } }
        public override DateTime CreationDate { get { return _real.Value.CreationDate; } }
        public override Customer Customer { get { return _real.Value.Customer; } }
        public override IList<OrderLine> OrderLines { get { return _real.Value.OrderLines; } }

        public DraftProxy(DataContext context, int id)
            : base(null)
        {
            _real = new Lazy<Draft>(() => new DraftMapper(context).Get(id));
        }
    }
}

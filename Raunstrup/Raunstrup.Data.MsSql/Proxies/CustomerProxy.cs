using System;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Proxies
{
    class CustomerProxy : Customer
    {
        private readonly Lazy<Customer> _real; 

        public CustomerProxy(DataContext context, int id)
        {
            _real = new Lazy<Customer>(() => new CustomerMapper(context).Get(id));
        }

        public override int Id { get { return _real.Value.Id; } }

        public override string Name { get { return _real.Value.Name; } }

        public override string StreetName { get { return _real.Value.StreetName; } }

        public override string StreetNumber { get { return _real.Value.StreetNumber; } }

        public override string City { get { return _real.Value.City; } }

        public override string PostalCode { get { return _real.Value.PostalCode; } }
    }
}

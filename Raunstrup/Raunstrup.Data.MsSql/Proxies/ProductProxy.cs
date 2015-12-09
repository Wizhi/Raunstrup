using System;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Proxies
{
    class ProductProxy : Product
    {
        private readonly Lazy<Product> _real;

        public override int Id { get { return _real.Value.Id; } }
        public override string Name { get { return _real.Value.Name; } }
        public override decimal SalesPrice { get { return _real.Value.SalesPrice; } }

        public ProductProxy(DataContext context, int id)
        {
            _real = new Lazy<Product>(() => new ProductMapper(context).Get(id));
        }
    }
}

using Raunstrup.Core.Domain;

namespace Raunstrup.Core.Repositories
{
    internal class ProductRepository : GenericInMemoryStorage<int, Product>, IProductRepository
    {
        protected override int GetKey(Product entity)
        {
            return entity.Id;
        }
    }
}
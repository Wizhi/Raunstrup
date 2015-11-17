using Raunstrup.Core.Domain;

namespace Raunstrup.Core.Repositories
{
    internal class ProductRepository : GenericInMemoryStorage<Product>, IProductRepository
    {
        protected override void SetId(Product entity, int id)
        {
            entity.Id = id;
        }

        protected override int GetId(Product entity)
        {
            return entity.Id;
        }
    }
}
using Raunstrup.Model;

namespace Raunstrup.Core.Repositories
{
    public class ProductRepository : GenericInMemoryStorage<Product>, IProductRepository
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
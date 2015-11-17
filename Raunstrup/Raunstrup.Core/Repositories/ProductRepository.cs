using System.Collections.Generic;
using Raunstrup.Core.Domain;

namespace Raunstrup.Core.Repositories
{
    class ProductRepository : IProductRepository
    {
        private readonly IDictionary<int, Product> _storage = new Dictionary<int, Product>(); 

        public Product Get(int id)
        {
            Product product;

            if (_storage.TryGetValue(id, out product))
            {
                return product;
            }

            throw new KeyNotFoundException();
        }

        public void Save(Product entity)
        {
            _storage[entity.Id] = entity;
        }

        public void Delete(Product entity)
        {
            _storage.Remove(entity.Id);
        }
    }
}

using System.Collections.Generic;
using Raunstrup.Core.Domain;

namespace Raunstrup.Core.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly IDictionary<int, Customer> _storage = new Dictionary<int, Customer>();

        public Customer Get(int id)
        {
            Customer customer;

            if (_storage.TryGetValue(id, out customer))
            {
                return customer;
            }

            throw new KeyNotFoundException();
        }

        public void Save(Customer entity)
        {
            _storage[entity.Id] = entity;
        }

        public void Delete(Customer entity)
        {
            _storage.Remove(entity.Id);
        }
    }
}

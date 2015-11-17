using Raunstrup.Core.Domain;

namespace Raunstrup.Core.Repositories
{
    class CustomerRepository : GenericInMemoryStorage<int, Customer>, ICustomerRepository
    {
        protected override int GetKey(Customer entity)
        {
            return entity.Id;
        }
    }
}

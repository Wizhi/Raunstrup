using Raunstrup.Model;

namespace Raunstrup.Core.Repositories
{
    class CustomerRepository : GenericInMemoryStorage<Customer>, ICustomerRepository
    {
        protected override void SetId(Customer entity, int id)
        {
            entity.Id = id;
        }

        protected override int GetId(Customer entity)
        {
            return entity.Id;
        }
    }
}

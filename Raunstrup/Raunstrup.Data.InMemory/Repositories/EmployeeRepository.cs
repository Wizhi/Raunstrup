using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Data.InMemory.Repositories
{
    public class EmployeeRepository : GenericInMemoryStorage<Employee>, IEmployeeRepository
    {
        protected override void SetId(Employee entity, int id)
        {
            entity.Id = id;
        }

        protected override int GetId(Employee entity)
        {
            return entity.Id;
        }
    }
}

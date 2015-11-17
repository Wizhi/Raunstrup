using Raunstrup.Core.Domain;

namespace Raunstrup.Core.Repositories
{
    class EmployeeRepository : GenericInMemoryStorage<int, Employee>, IEmployeeRepository
    {
        protected override int GetKey(Employee entity)
        {
            return entity.Id;
        }
    }
}

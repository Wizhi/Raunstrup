using Raunstrup.Model;

namespace Raunstrup.Core.Repositories
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

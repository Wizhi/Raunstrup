using System.Collections.Generic;
using Raunstrup.Core.Domain;

namespace Raunstrup.Core.Repositories
{
    class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDictionary<int, Employee> _storage = new Dictionary<int, Employee>();

        public Employee Get(int id)
        {
            Employee employee;

            if (_storage.TryGetValue(id, out employee))
            {
                return employee;
            }

            throw new KeyNotFoundException();
        }

        public void Save(Employee entity)
        {
            _storage[entity.Id] = entity;
        }

        public void Delete(Employee entity)
        {
            _storage.Remove(entity.Id);
        }
    }
}

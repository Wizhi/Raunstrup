using System;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Proxies
{
    class EmployeeProxy : Employee
    {
        private readonly EmployeeMapper _mapper;
        private readonly Lazy<Employee> _real;

        public override int Id { get { return _real.Value.Id; }  }
        public override string Name { get { return _real.Value.Name; } }

        public EmployeeProxy(DataContext connection, int id)
        {
            _real = new Lazy<Employee>(() => new EmployeeMapper(connection).Get(id));
        }
    }
}

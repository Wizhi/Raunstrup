using System;
using System.Collections.Generic;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Proxies
{
    class EmployeeProxy : Employee
    {
        private readonly Lazy<Employee> _real;

        public EmployeeProxy(DataContext context, int id)
        {
            _real = new Lazy<Employee>(() => new EmployeeMapper(context).Get(id));
        }

        public override int Id { get { return _real.Value.Id; } }
        public override string Name { get { return _real.Value.Name; } }
        public override IList<Skill> Skills { get { return _real.Value.Skills; } }
    }
}

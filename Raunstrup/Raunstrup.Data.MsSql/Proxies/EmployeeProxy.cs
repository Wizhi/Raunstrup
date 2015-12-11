using System;
using System.Collections.Generic;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Data.MsSql.Query;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Proxies
{
    class EmployeeProxy : Employee
    {
        private readonly Lazy<Employee> _real;
        private readonly Lazy<IList<Skill>> _skills; 

        public EmployeeProxy(DataContext context, int id)
        {
            _real = new Lazy<Employee>(() => new EmployeeMapper(context).Get(id));
            _skills = new Lazy<IList<Skill>>(() => new SkillsByEmployeeQuery(id).Execute(context));
        }
        
        public EmployeeProxy(DataContext context, Employee employee)
        {
            _real = new Lazy<Employee>(() => employee);
            _skills = new Lazy<IList<Skill>>(() => new SkillsByEmployeeQuery(employee.Id).Execute(context));
        }

        public override int Id { get { return _real.Value.Id; } }
        public override string Name { get { return _real.Value.Name; } }
        public override IList<Skill> Skills { get { return _skills.Value; } }
    }
}
